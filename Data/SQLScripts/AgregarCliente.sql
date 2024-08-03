USE AppGymDB;
GO

CREATE PROCEDURE RegistrarClienteYFichaMedicas    
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @edad int,
    @dni int,
    @sexo NVARCHAR(10),
    @fechaNacimiento DATETIME,
    @direccion NVARCHAR(50),
    @localidad NVARCHAR(50),
    @codigoPostal int,
    @grupoSanguineo NVARCHAR(10),
    @telefono int,
    @telefonoEmergencia int,
    @correo NVARCHAR(50),
    @fechaInscripcion DATETIME,
    @metodoDePago NVARCHAR(10),
    @valorDeCuota int
AS
BEGIN
    -- Comienza una transacci�n
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Inserta el nuevo cliente
        INSERT INTO Cliente (nombre, apellido, edad, dni, sexo, fechaNacimiento, direccion, localidad, codigoPostal, grupoSanguineo, telefono, telefonoEmergencia, correo, fechaInscripcion , metodoDePago, valorDeCuota)
        VALUES (@nombre, @apellido, @edad, @dni, @sexo, @fechaNacimiento, @direccion, @localidad, @codigoPostal, @grupoSanguineo, @telefono, @telefonoEmergencia, @correo, @fechaInscripcion , @metodoDePago, @valorDeCuota);

        -- Obt�n el ID del cliente reci�n insertado
        DECLARE @ClienteId INT;
        SET @ClienteId = SCOPE_IDENTITY();

        -- Inserta la ficha m�dica asociada
        INSERT INTO FichaMedica (cliente_id)
        VALUES (@ClienteId);

        -- Si todo va bien, confirma la transacci�n
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Si hay un error, deshace la transacci�n
        ROLLBACK TRANSACTION;
        -- Lanza el error para manejo adicional
        THROW;
    END CATCH
END
