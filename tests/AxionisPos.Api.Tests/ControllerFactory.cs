using System.Security.Claims;
using AxionisPos.Api.Controllers;
using AxionisPos.Api.Data;
using AxionisPos.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using AppOptions = AxionisPos.Api.Options.AppOptions;

namespace AxionisPos.Api.Tests;

internal static class ControllerFactory
{
    public static ConsignmentBatchesController MakeConsignmentBatchesController(
        TestDb tdb,
        SupplierInvoicePdfParser? parser = null,
        string? testDataDir = null,
        string userName = "test-user")
        => BuildController(tdb.NewContext(), parser, testDataDir, userName);

    private static ConsignmentBatchesController BuildController(
        AxionisDbContext db,
        SupplierInvoicePdfParser? parser,
        string? testDataDir,
        string userName)
    {
        var app = Microsoft.Extensions.Options.Options.Create(new AppOptions
        {
            PdfStoragePath = testDataDir ?? Path.Combine(Path.GetTempPath(), "axionis-test-pdfs-" + Guid.NewGuid().ToString("N"))
        });

        var controller = new ConsignmentBatchesController(
            db,
            pdf: null!,
            invoicePdfParser: parser ?? new SupplierInvoicePdfParser(),
            app: app);

        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
        }, "TestAuth");

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = new ClaimsPrincipal(identity)
            }
        };
        return controller;
    }

    public static T Unwrap<T>(ActionResult<T> result)
    {
        if (result.Result is ObjectResult ok && ok.Value is T v)
            return v;
        if (result.Value is T val)
            return val;
        throw new InvalidOperationException(
            $"Expected ActionResult of {typeof(T).Name} but got {result.Result?.GetType().Name ?? "null"}: " +
            ((result.Result as ObjectResult)?.Value?.ToString() ?? "<no value>"));
    }
}
