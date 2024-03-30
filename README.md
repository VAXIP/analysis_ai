# AI Analysis Service

## Descripción

`AI Analysis` es un innovador servicio de análisis de ventas diseñado para explorar y maximizar las posibilidades que ofrece la inteligencia artificial (IA) en la interpretación y gestión de datos de ventas. Este servicio interactúa con un asistente de IA para ofrecer un análisis detallado y preciso de las ventas dentro de rangos de fechas específicos, permitiendo a las empresas y usuarios obtener insights valiosos sobre sus operaciones comerciales.

Mediante la administración eficiente de hilos de conversación y la utilización de un conector AI específico, `AI Analysis` procesa datos de ventas para generar análisis ricos en información, tendencias de ventas, análisis de rentabilidad, proyecciones de ventas futuras, recomendaciones de inventario, y oportunidades de marketing basadas en patrones históricos y actuales de ventas.

El objetivo de `AI Analysis` es no solo proveer un servicio de análisis de ventas más eficiente y automatizado sino también abrir nuevas vías de exploración en el uso de la inteligencia artificial para mejorar las estrategias de negocio, optimizar las operaciones de venta y aumentar la comprensión del comportamiento del mercado.

Este enfoque centrado en la IA representa un paso adelante en cómo las empresas pueden utilizar la tecnología para obtener una ventaja competitiva, adaptándose rápidamente a cambios en el mercado y respondiendo de manera más efectiva a las necesidades de sus clientes.

## Características

- Recuperación de análisis de ventas para rangos de fechas específicos.
- Interacción con un asistente de IA para el procesamiento de datos de ventas.
- Gestión eficiente de hilos de conversación y operaciones de base de datos relacionadas con los registros de ventas.

## Tecnologías Utilizadas

- IOpenAICompletionConnector para la interacción con el asistente de IA.
- ILogger para el registro de actividades y errores.
- ISalesRecordRepository para operaciones de base de datos con registros de ventas.
- IJsonExtractor para la extracción y análisis de respuestas JSON del asistente de IA.

## Cómo Empezar

### Prerrequisitos

- .NET 8.0 o superior.
- Acceso a la API de OpenAI (se requiere una clave API).

### Configuración

1. Clona el repositorio a tu máquina local.
2. Asegúrate de tener instalado .NET 8.0 o superior.
3. Configura las credenciales de la API de OpenAI en el archivo de configuración `appsettings.json`.

```json
{
  "OpenAI": {
    "ApiKey": "TU_CLAVE_API_AQUI",
    "OrganizationId": "TU_ORGANIZACION_ID"
  }
  ,
  "ConnectionStrings": {
    "cnnstr": "TU_CADENA_CONEXION"
  }
}
```
