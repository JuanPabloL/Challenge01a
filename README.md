## Desarrollo
  La solucion se basa en uno de los laboratorios de la clase, se crea una solucion desde cero y se van agregando los proyectos y clases necesarias.

## Repositorio
  https://github.com/JuanPabloL/Challenge01a.git

## App Service EndPoint
  https://aswaltchallenge01ajplg.azurewebsites.net/api/

## Funcionalidad

## Test Crear Tarea
  http method: POST
  uri:  https://aswaltchallenge01ajplg.azurewebsites.net/api/task/Create
  body: {  "titulo": "Task Eight",   "descripcion": "Description Task 8" }

## Test Consultar todas las Tareas
  http method: GET
  uri:  https://aswaltchallenge01ajplg.azurewebsites.net/api/task/getall

## Test Consultar tarea por su identificador
  http method: GET
  uri:  https://aswaltchallenge01ajplg.azurewebsites.net/api/Task/GetById?Id=3875715b-ce8a-42ae-14ed-08dc97d9464d

## Test Marcar tarea como completada
  http method: PUT
  uri: https://aswaltchallenge01ajplg.azurewebsites.net/api/task/SetTaskCompleted
  body:  {  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6" }

## Eliminar tarea
  http method: DELETE
  uri: https://aswaltchallenge01ajplg.azurewebsites.net/api/task/DeleteTask
  body:  {  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6" }  

## Tabla en Base de Datos
CREATE TABLE [dbo].[Task](
	[TaskId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](40) NULL,
	[DateTime] [datetime] NULL,
	[Description] [varchar](100) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_TaskId]  DEFAULT (newid()) FOR [TaskId]
GO


