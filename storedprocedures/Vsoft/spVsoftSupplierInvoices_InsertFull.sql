CREATE PROCEDURE [spVsoftSupplierInvoices_InsertFull]
    @Id nvarchar(11),
    @V035 nvarchar(8),
    @V066 nvarchar(50),
    @V036 nvarchar(8),
    @V037 nvarchar(10),
    @V038 nvarchar(8),
    @V249 nvarchar(12),
    @Decv249 money,
    @V039 nvarchar(20),
    @Vs03 nvarchar(3),
    @V040 nvarchar(15),
    @Decv040 money,
    @V041 nvarchar(1),
    @V245 nvarchar(50),
    @V246 nvarchar(50),
    @RvDm nvarchar(50),
    @BstndNaam37 nvarchar(255),
    @TypeZending37 nvarchar(5),
    @BstBlob37 varbinary(max),
    @V042 nvarchar(10),
    @V043 nvarchar(10),
    @V044 nvarchar(10),
    @V045 nvarchar(10),
    @V046 nvarchar(10),
    @V047 nvarchar(10),
    @V048 nvarchar(10),
    @V049 nvarchar(10),
    @V050 nvarchar(10),
    @V051 nvarchar(10),
    @V052 nvarchar(10),
    @V053 nvarchar(10),
    @V054 nvarchar(10),
    @Decv042 money,
    @Decv043 money,
    @Decv044 money,
    @Decv045 money,
    @Decv046 money,
    @Decv047 money,
    @Decv048 money,
    @Decv049 money,
    @Decv050 money,
    @Decv051 money,
    @Decv052 money,
    @Decv053 money,
    @Decv054 money,
    @VsoftSupplierId nvarchar(12)
AS
BEGIN
    SET NOCOUNT ON
    INSERT INTO VsoftSupplierInvoices
        ( Id, V035, V066, V036, V037, V038, V249, Decv249, V039, Vs03, V040, Decv040,
        V041, V245, V246, RvDm, BstndNaam37, TypeZending37, BstBlob37, V042, V043,
        V044, V045, V046, V047, V048, V049, V050, V051, V052, V053, V054, Decv042,
        Decv043, Decv044, Decv045, Decv046, Decv047, Decv048, Decv049, Decv050,
        Decv051, Decv052, Decv053, Decv054, VsoftSupplierId )
    VALUES
        ( @Id, @V035, @V066, @V036, @V037, @V038, @V249, @Decv249, @V039, @Vs03, @V040,
            @Decv040, @V041, @V245, @V246, @RvDm, @BstndNaam37, @TypeZending37, @BstBlob37,
            @V042, @V043, @V044, @V045, @V046, @V047, @V048, @V049, @V050, @V051, @V052,
            @V053, @V054, @Decv042, @Decv043, @Decv044, @Decv045, @Decv046, @Decv047, @Decv048,
            @Decv049, @Decv050, @Decv051, @Decv052, @Decv053, @Decv054, @VsoftSupplierId )
END