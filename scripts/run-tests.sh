#!/usr/bin/env bash
# Runs the AxionisPos.Api.Tests xUnit suite in a disposable .NET 8 SDK container.
set -euo pipefail

ROOT="$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )/.." &> /dev/null && pwd )"
echo "Running dotnet tests from $ROOT"

docker run --rm \
    -v "$ROOT":/src \
    -w /src \
    mcr.microsoft.com/dotnet/sdk:8.0 \
    dotnet test tests/AxionisPos.Api.Tests/AxionisPos.Api.Tests.csproj --nologo --verbosity minimal

echo "All backend tests passed."
