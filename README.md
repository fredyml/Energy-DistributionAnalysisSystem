# EnergyDistributionAnalysisSystem
# Energy Distribution Analysis System

El Energy Distribution Analysis System es una aplicación que permite a los clientes de una empresa de distribución de energía acceder a información ejecutiva para tomar decisiones informadas sobre el mantenimiento y la evaluación de los tramos de distribución de energía eléctrica. La aplicación utiliza datos históricos de consumo, costos y pérdidas proporcionados por el cliente para ofrecer información detallada sobre el rendimiento de los tramos.

## Requerimientos

La aplicación debe proporcionar tres endpoints que permitan obtener información específica sobre los tramos de distribución de energía eléctrica:

### Request 1: Histórico de Consumos por Tramos

Este endpoint permite obtener un historial de consumo, pérdidas y costos por consumo para cada tramo dentro de un período de tiempo específico.

**Endpoint:** GET /energy/historical-segments

**Parámetros de consulta:**
- startDate (obligatorio): Fecha inicial en formato 'yyyy-MM-dd'.
- endDate (obligatorio): Fecha final en formato 'yyyy-MM-dd'.

**Respuesta:**
La respuesta incluirá un objeto JSON con el historial de consumo, pérdidas y costos por consumo para cada tramo.

### Request 2: Histórico de Consumos por Cliente

Este endpoint permite obtener un historial de consumo, pérdidas y costos por consumo para cada tipo de cliente (residencial, comercial, industrial) dentro de un período de tiempo específico.

**Endpoint:** GET /energy/historical-customer

**Parámetros de consulta:**
- startDate (obligatorio): Fecha inicial en formato 'yyyy-MM-dd'.
- endDate (obligatorio): Fecha final en formato 'yyyy-MM-dd'.
- customerType (obligatorio): Tipo de cliente ('residencial', 'comercial' o 'industrial').

**Respuesta:**
La respuesta incluirá un objeto JSON con el historial de consumo, pérdidas y costos por consumo para cada tipo de cliente.

### Request 3: Top 20 Peores Tramos/Cliente

Este endpoint permite obtener un listado de los 20 tramos/cliente con las mayores pérdidas dentro de un período de tiempo específico. Esto ayudará a identificar los tramos que generan mayores pérdidas y planificar acciones de mantenimiento correctivo o preventivo.

**Endpoint:** GET /energy/top-segments-customer

**Parámetros de consulta:**
- startDate (obligatorio): Fecha inicial en formato 'yyyy-MM-dd'.
- endDate (obligatorio): Fecha final en formato 'yyyy-MM-dd'.

**Respuesta:**
La respuesta incluirá un objeto JSON con el listado de los 20 tramos/cliente con las mayores pérdidas.

## Arquitectura

El Energy Distribution Analysis System sigue una arquitectura limpia (Clean Architecture) para lograr una separación clara de responsabilidades y una fácil escalabilidad y mantenibilidad del sistema. La arquitectura consta de las siguientes capas:

- **Domain:** Contiene las entidades y reglas de negocio del dominio.
- **Application:** Contiene los servicios de aplicación que implementan la lógica de la aplicación y orquestan las operaciones entre las capas de dominio e infraestructura.
- **Infrastructure:** Contiene las implementaciones concretas de las interfaces definidas en las capas de dominio y aplicación. Incluye la persistencia de datos, la comunicación con servicios externos y otros componentes de infraestructura.
- **API:** Contiene los controladores de la API que definen los endpoints y gestionan las solicitudes y respuestas HTTP. También incluye filtros y middleware para el manejo de excepciones y la configuración de la aplicación.

## Tecnologías utilizadas

La aplicación utiliza las siguientes tecnologías y herramientas:

- ASP.NET Core: Framework para el desarrollo de aplicaciones web.
- Entity Framework Core: ORM (Object-Relational Mapping) para el acceso a la base de datos.
- SQL Server: Motor de base de datos relacional para almacenar los datos históricos.
- NLog: Biblioteca para el registro de eventos y generación de logs.
- Microsoft.Extensions.Logging: Biblioteca para el registro de eventos y generación de logs.

## Configuración

La configuración de la aplicación se realiza a través del archivo `appsettings.json`, que se encuentra en la raíz del proyecto. En este archivo se pueden configurar los siguientes aspectos:

- Nivel de registro de eventos y generación de logs.
- Cadena de conexión a la base de datos.

## Ejecución

Para ejecutar la aplicación, siga los siguientes pasos:

1. Asegúrese de tener instalado .NET Core SDK en su máquina.
2. Clone el repositorio del Energy Distribution Analysis System.
3. Navegue hasta el directorio raíz del proyecto en la línea de comandos.
4. Ejecute el siguiente comando para compilar la aplicación:
   ```
   dotnet build
   ```
5. Ejecute el siguiente comando para iniciar la aplicación:
   ```
   dotnet run
   ```
6. La aplicación estará disponible en la siguiente URL: `http://localhost:5000` o `https://localhost:5001` (si se habilitó HTTPS).

## Equipo

El Energy Distribution Analysis System fue desarrollado por Fredy Mendoza.
