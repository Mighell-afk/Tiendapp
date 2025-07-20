
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title>Menú de Inicio</title>
    
    <style>
        body {
            font-family: Arial, sans-serif;
/*            background-color: #f4f4f4;*/
            margin: 0;
            padding: 0;
        }

        nav {
/*            background-color: #333;*/
            padding: 10px 0;
            text-align: center;
        }

            nav a {
/*                color: white;*/
                text-decoration: none;
                margin: 0 15px;
                font-size: 18px;
            }

                nav a:hover {
                    text-decoration: underline;
                }

        .contenido {
            padding: 20px;
            text-align: center;
        }
    </style>

</head>
<body>

    <nav>
        <a href="index.html">Inicio</a>
        <a href="acerca.html">Acerca de</a>
        <a href="contacto.html">Contacto</a>
        <a href="ayuda.html">Ayuda</a>
    </nav>

    <div class="contenido">
        <h1>Bienvenido al Sistema</h1>
        <p>Este es un menú básico hecho con HTML y un poco de CSS.</p>
    </div>

    <div class="abm-section">
        <h2>Gestión de Tablas Menores (ABM)</h2>
        <div class="abm-links">
            <ul>
                <li><a href="/Ciudad/Index">Ciudad</a></li>
                <li><a href="especialidades.html">Tipo de pago</a></li>
            </ul>
             
        </div>
    </div>

</body>
</html>
