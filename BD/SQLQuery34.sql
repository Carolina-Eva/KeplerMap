USE [KeplerMap]
GO
/****** Object:  Table [dbo].[Elemento]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Elemento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Tipo] [nvarchar](50) NULL,
	[Masa] [float] NULL,
	[Distancia] [float] NULL,
	[TipoObjetoId] [int] NULL,
	[EsGrupo] [bit] NOT NULL,
 CONSTRAINT [PK__Elemento__3214EC0790063D72] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RelacionElemento]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RelacionElemento](
	[Id_Grupo] [int] NOT NULL,
	[Id_Hijo] [int] NOT NULL,
 CONSTRAINT [PK_RelacionElemento] PRIMARY KEY CLUSTERED 
(
	[Id_Grupo] ASC,
	[Id_Hijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoObjeto]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoObjeto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TipoObjeto] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Elemento] ON 
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (1, N'Supercúmulo de Virgo', N'Supercumulo', NULL, NULL, 1, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (2, N'Cúmulo de Coma', N'Cumulo', NULL, NULL, 2, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (3, N'Galaxia NGC 4889', N'Galaxia', 1000000000000, 300, 3, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (4, N'Sistema Solar', N'Sistema Planetario', NULL, NULL, 4, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (5, N'Sol', N'Estrella', 1.989E+30, 0, 5, 0)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (6, N'Tierra', N'Planeta', 5.972E+24, 1, 6, 0)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (7, N'Galaxia NGC 4874', N'Galaxia', 7.347E+22, 0.00257, 3, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (8, N'Hydrus HD 10180', N'Sistema Planetario', 1.898E+27, 5.2, 4, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (9, N'Gliese 581', N'Sistema Planetario', 8.9319E+22, 0.0028, 4, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (10, N'HD 10180 b', N'Planeta', 4.799E+22, 0.0045, 6, 0)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (1003, N'C/1980 E1 (Bowell)', N'Cometa', 4000, NULL, 1008, 0)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (1006, N'C/2000 U5 (LINEAR)', N'Cometa', 5000, NULL, 1008, 0)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (1018, N'Marte', N'Planeta', 345345, 3453, NULL, 0)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (1019, N'HD 342', N'Planeta', 23423, 5456, NULL, 0)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (1021, N'Cúmulo Z35', N'Cúmulo', 555555, 677777777, NULL, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (1022, N'Galaxia Andromeda', N'Galaxia', 5555, 234234, NULL, 1)
GO
INSERT [dbo].[Elemento] ([Id], [Nombre], [Tipo], [Masa], [Distancia], [TipoObjetoId], [EsGrupo]) VALUES (1023, N'HD 234', N'Cometa', 3333, 1, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Elemento] OFF
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (1, 2)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (1, 1021)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (2, 3)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (2, 7)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (3, 4)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (3, 1003)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (3, 1006)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (4, 5)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (4, 6)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (4, 1018)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (6, 7)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (7, 8)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (7, 9)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (8, 10)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (9, 1019)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (1021, 1022)
GO
INSERT [dbo].[RelacionElemento] ([Id_Grupo], [Id_Hijo]) VALUES (1022, 1023)
GO
SET IDENTITY_INSERT [dbo].[TipoObjeto] ON 
GO
INSERT [dbo].[TipoObjeto] ([Id], [TipoObjeto]) VALUES (1008, N'Cometa')
GO
INSERT [dbo].[TipoObjeto] ([Id], [TipoObjeto]) VALUES (2, N'Cúmulo')
GO
INSERT [dbo].[TipoObjeto] ([Id], [TipoObjeto]) VALUES (5, N'Estrella')
GO
INSERT [dbo].[TipoObjeto] ([Id], [TipoObjeto]) VALUES (3, N'Galaxia')
GO
INSERT [dbo].[TipoObjeto] ([Id], [TipoObjeto]) VALUES (7, N'Luna')
GO
INSERT [dbo].[TipoObjeto] ([Id], [TipoObjeto]) VALUES (6, N'Planeta')
GO
INSERT [dbo].[TipoObjeto] ([Id], [TipoObjeto]) VALUES (4, N'SistemaSolar')
GO
INSERT [dbo].[TipoObjeto] ([Id], [TipoObjeto]) VALUES (1, N'Supercúmulo')
GO
SET IDENTITY_INSERT [dbo].[TipoObjeto] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 
GO
INSERT [dbo].[Usuario] ([Id], [Usuario], [Password]) VALUES (1, N'Prueba', N'Prueba')
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__TipoObje__75112F1EE94E5068]    Script Date: 7/8/2025 16:55:38 ******/
ALTER TABLE [dbo].[TipoObjeto] ADD UNIQUE NONCLUSTERED 
(
	[TipoObjeto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Elemento] ADD  CONSTRAINT [DF__Elemento__EsGrup__3A81B327]  DEFAULT ((0)) FOR [EsGrupo]
GO
ALTER TABLE [dbo].[Elemento]  WITH CHECK ADD  CONSTRAINT [FK_Elemento_TipoObjeto] FOREIGN KEY([TipoObjetoId])
REFERENCES [dbo].[TipoObjeto] ([Id])
GO
ALTER TABLE [dbo].[Elemento] CHECK CONSTRAINT [FK_Elemento_TipoObjeto]
GO
ALTER TABLE [dbo].[RelacionElemento]  WITH CHECK ADD  CONSTRAINT [FK_RelacionElemento_Grupo] FOREIGN KEY([Id_Grupo])
REFERENCES [dbo].[Elemento] ([Id])
GO
ALTER TABLE [dbo].[RelacionElemento] CHECK CONSTRAINT [FK_RelacionElemento_Grupo]
GO
ALTER TABLE [dbo].[RelacionElemento]  WITH CHECK ADD  CONSTRAINT [FK_RelacionElemento_Hijo] FOREIGN KEY([Id_Hijo])
REFERENCES [dbo].[Elemento] ([Id])
GO
ALTER TABLE [dbo].[RelacionElemento] CHECK CONSTRAINT [FK_RelacionElemento_Hijo]
GO
ALTER TABLE [dbo].[RelacionElemento]  WITH CHECK ADD  CONSTRAINT [CK_RelacionElemento_NoCiclo] CHECK  (([Id_Grupo]<>[Id_Hijo]))
GO
ALTER TABLE [dbo].[RelacionElemento] CHECK CONSTRAINT [CK_RelacionElemento_NoCiclo]
GO
/****** Object:  StoredProcedure [dbo].[AGREGAR_ELEMENTO]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_ELEMENTO]
    @Nombre NVARCHAR(100),
    @Tipo NVARCHAR(50) = NULL,
    @Masa FLOAT = NULL,
    @Distancia FLOAT = NULL,
    @EsGrupo BIT,
    @PadreId INT = NULL -- si se pasa, crea relación con el padre
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NuevoId INT;

    -- Insertar el nuevo elemento
    INSERT INTO Elemento (Nombre, Tipo, Masa, Distancia, EsGrupo)
    VALUES (@Nombre, @Tipo, @Masa, @Distancia, @EsGrupo);

    SET @NuevoId = SCOPE_IDENTITY();

    -- Si se especifica padre, crear relación en RelacionElemento
    IF @PadreId IS NOT NULL
    BEGIN
        INSERT INTO RelacionElemento (Id_Grupo, Id_Hijo)
        VALUES (@PadreId, @NuevoId);
    END

    SELECT @NuevoId AS NuevoElementoId;
END
GO
/****** Object:  StoredProcedure [dbo].[AGREGAR_RELACION_ELEMENTO]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_RELACION_ELEMENTO]
    @IdGrupo INT,
    @IdHijo INT
AS
BEGIN
    SET NOCOUNT ON;
    IF @IdGrupo = @IdHijo
    BEGIN
        RAISERROR('No se puede asignar un elemento como hijo de sí mismo.', 16, 1);
        RETURN;
    END

    INSERT INTO RelacionElemento (Id_Grupo, Id_Hijo)
    VALUES (@IdGrupo, @IdHijo);
END
GO
/****** Object:  StoredProcedure [dbo].[BORRAR_ELEMENTO]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BORRAR_ELEMENTO]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar existencia
    IF NOT EXISTS (SELECT 1 FROM Elemento WHERE Id = @Id)
    BEGIN
        RAISERROR('El elemento no existe.', 16, 1);
        RETURN;
    END

    -- Verificar si tiene relaciones como padre
    IF EXISTS (SELECT 1 FROM RelacionElemento WHERE Id_Grupo = @Id)
    BEGIN
        RAISERROR('No se puede eliminar: el elemento tiene hijos asociados.', 16, 1);
        RETURN;
    END

    -- Verificar si está asociado como hijo en otro grupo
    IF EXISTS (SELECT 1 FROM RelacionElemento WHERE Id_Hijo = @Id)
    BEGIN
        RAISERROR('No se puede eliminar: el elemento está asociado a un grupo.', 16, 1);
        RETURN;
    END

    -- Eliminar
    DELETE FROM Elemento WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_ELEMENTO]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_ELEMENTO]
    @ElementoId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Validar que el elemento exista
    IF NOT EXISTS(SELECT 1 FROM Elemento WHERE Id = @ElementoId)
    BEGIN
        RAISERROR('El elemento no existe.', 16, 1);
        RETURN;
    END

    -- 2. Verificar si el elemento tiene hijos en RelacionElemento
    IF EXISTS(SELECT 1 FROM RelacionElemento WHERE Id_Grupo = @ElementoId)
    BEGIN
        RAISERROR('No se puede eliminar el elemento porque tiene elementos hijos asociados.', 16, 1);
        RETURN;
    END

    -- 3. Eliminar relaciones donde este elemento sea hijo (desvincularlo de padres)
    DELETE FROM RelacionElemento WHERE Id_Hijo = @ElementoId;

    -- 4. Eliminar el elemento
    DELETE FROM Elemento WHERE Id = @ElementoId;
END
GO
/****** Object:  StoredProcedure [dbo].[ELIMINAR_RELACION_ELEMENTO]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ELIMINAR_RELACION_ELEMENTO]
    @IdGrupo INT,
    @IdHijo INT
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Verificar si existe la relación
    IF NOT EXISTS(SELECT 1 FROM RelacionElemento WHERE Id_Grupo = @IdGrupo AND Id_Hijo = @IdHijo)
    BEGIN
        RAISERROR('No existe una relación entre el grupo y el elemento especificado.', 16, 1);
        RETURN;
    END

    -- 2. Borrar la relación
    DELETE FROM RelacionElemento
    WHERE Id_Grupo = @IdGrupo AND Id_Hijo = @IdHijo;
END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_ELEMENTOS]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_ELEMENTOS]
AS
BEGIN
    SET NOCOUNT ON;

    -- CTE recursiva para recorrer relaciones padre-hijo
    WITH recursivo AS (
        SELECT 
            re.Id_Grupo AS id_padre,
            re.Id_Hijo AS id_hijo
        FROM RelacionElemento re

        UNION ALL

        SELECT 
            re.Id_Grupo,
            re.Id_Hijo
        FROM RelacionElemento re
        INNER JOIN recursivo r ON r.id_hijo = re.Id_Grupo
    )

    -- Seleccionamos todos los elementos relacionados (hijos con sus padres)
    SELECT DISTINCT
        r.id_padre,
        r.id_hijo,
        e.Id AS ElementoId,
        e.Nombre,
        e.Tipo,
        e.Masa,
        e.Distancia,
        e.EsGrupo
    FROM recursivo r
    INNER JOIN Elemento e ON r.id_hijo = e.Id

    -- UNION para agregar los elementos raíz (los que no son hijos de nadie)
    UNION

    SELECT 
        NULL AS id_padre,
        e.Id AS id_hijo,
        e.Id AS ElementoId,
        e.Nombre,
        e.Tipo,
        e.Masa,
        e.Distancia,
        e.EsGrupo
    FROM Elemento e
    WHERE e.Id NOT IN (SELECT Id_Hijo FROM RelacionElemento);
END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_ELEMENTOS_HIJOS]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_ELEMENTOS_HIJOS]
    @ElementoId INT
AS
BEGIN
    SET NOCOUNT ON;

    -- CTE recursiva: obtiene solo hijos de grupos válidos
    WITH recursivo AS (
        SELECT 
            re.Id_Grupo AS id_padre,
            re.Id_Hijo AS id_hijo
        FROM RelacionElemento re
        INNER JOIN Elemento p ON re.Id_Grupo = p.Id
        WHERE re.Id_Grupo = @ElementoId AND p.EsGrupo = 1  

        UNION ALL

        SELECT 
            re.Id_Grupo,
            re.Id_Hijo
        FROM RelacionElemento re
        INNER JOIN recursivo r ON r.id_hijo = re.Id_Grupo
        INNER JOIN Elemento p ON re.Id_Grupo = p.Id
        WHERE p.EsGrupo = 1   
    )

    SELECT DISTINCT
        r.id_padre,
        r.id_hijo,
        e.Id AS ElementoId,
        e.Nombre,
        e.Tipo,
        e.Masa,
        e.Distancia,
        e.EsGrupo
    FROM recursivo r
    INNER JOIN Elemento e ON r.id_hijo = e.Id
END
GO
/****** Object:  StoredProcedure [dbo].[LISTAR_TIPO_OBJETO]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LISTAR_TIPO_OBJETO]
AS
BEGIN
 SELECT Id, TipoObjeto FROM TipoObjeto;
END
GO
/****** Object:  StoredProcedure [dbo].[LOGIN_USUARIO]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LOGIN_USUARIO]
    @Usuario NVARCHAR(50),
    @Password NVARCHAR(50)
AS
BEGIN
    SELECT COUNT(1)
    FROM Usuario
    WHERE Usuario = @Usuario AND Password = @Password
END
GO
/****** Object:  StoredProcedure [dbo].[MODIFICAR_ELEMENTO]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MODIFICAR_ELEMENTO]
    @Id INT,
    @Nombre NVARCHAR(100),
    @Tipo NVARCHAR(50) = NULL,
    @Masa FLOAT = NULL,
    @Distancia FLOAT = NULL,
    @EsGrupo BIT
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar que exista
    IF NOT EXISTS (SELECT 1 FROM Elemento WHERE Id = @Id)
    BEGIN
        RAISERROR('El elemento no existe.', 16, 1);
        RETURN;
    END

    -- Actualizar datos
    UPDATE Elemento
    SET Nombre = @Nombre,
        Tipo = @Tipo,
        Masa = @Masa,
        Distancia = @Distancia,
        EsGrupo = @EsGrupo
    WHERE Id = @Id;
END
GO
/****** Object:  StoredProcedure [dbo].[OBTENER_ELEMENTO_PORID]    Script Date: 7/8/2025 16:55:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OBTENER_ELEMENTO_PORID]
@ElementoId INT
AS
BEGIN
SELECT [Id]
      ,[Nombre]
      ,[Tipo]
      ,[Masa]
      ,[Distancia]
      ,[TipoObjetoId]
      ,[EsGrupo]
  FROM [KeplerMap].[dbo].[Elemento] Where [Id] = @ElementoId
 END
GO
