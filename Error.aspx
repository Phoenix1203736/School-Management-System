<%@ Page Language="C#" %>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Error</title>
    <link rel="stylesheet" href="/Content/bootstrap.min.css" />
    <style>
        body { background-color: #F2FAF8; font-family: 'Open Sans', system-ui, sans-serif; }
        .error-container {
            margin-top: 120px;
            max-width: 480px;
            margin-left: auto;
            margin-right: auto;
            padding: 32px;
        }
        .btn-primary {
            background-color: #0D9488;
            border-color: #0D9488;
        }
        .btn-primary:hover {
            background-color: #0B7E74;
            border-color: #0B7E74;
        }
        h2 { color: #134E4A; font-family: 'Poppins', system-ui, sans-serif; font-weight: 600; }
    </style>
</head>
<body>
    <div class="container">
        <div class="error bg-white shadow rounded">
            <h2 class="text-center">Error</h2>
            <p class="text-center text-muted">
                Ocurrió un error inesperado al procesar su solicitud.
                Intente nuevamente más tarde.
            </p>
            <div class="text-center">
                <a href="Default.aspx" class="btn btn-primary">Volver al inicio</a>
            </div>
        </div>
    </div>
</body>
</html>
