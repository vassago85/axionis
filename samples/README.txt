Sample demo data
-----------------
- demo-products.xlsx — sample product catalogue for testing and demos.
- demo-products.csv — exported from that workbook (same columns; UTF-8 with BOM).

Regenerate the CSV after Excel changes:
  docker run --rm -v "<repo>:/work" -w /work mcr.microsoft.com/dotnet/sdk:8.0 \
    dotnet run --project tools/ExportCsv/ExportCsv.csproj -- \
    samples/demo-products.xlsx samples/demo-products.csv "demo products"

Or from repo root with local dotnet:
  dotnet run --project tools/ExportCsv -- samples/demo-products.xlsx samples/demo-products.csv "demo products"

Import via web UI (Import page) or the provided import scripts.
