CREATE PROCEDURE [spVsoftLedgers_UpdateFull]
    @V070 nvarchar(15),
    @V034 nvarchar(13),
    @V066 nvarchar(8),
    @V033 nvarchar(11),
    @V038 nvarchar(8),
    @V035 nvarchar(8),
    @V067 nvarchar(35),
    @V068 nvarchar(12),
    @V069 nvarchar(7),
    @V041 nvarchar(1),
    @V249 nvarchar(50),
    @V248 nvarchar(12),
    @V245 nvarchar(50),
    @V246 nvarchar(50),
    @Dece068 money,
    @V102 nvarchar(max),
    @RvID int,
    @VsoftLedgerAccountId nvarchar(7)
AS
BEGIN
    SET NOCOUNT ON
    UPDATE VsoftLedgers SET  
    V070 = @V070,
    V034 = @V034,
    V066 = @V066,
    V033 = @V033,
    V038 = @V038,
    V035 = @V035,
    V067 = @V067,
    V068 = @V068,
    V069 = @V069,
    V041 = @V041,
    V249 = @V249,
    V248 = @V248,
    V245 = @V245,
    V246 = @V246,
    Dece068 = @Dece068,
    V102 = @V102,
    RvID = @RvID,
    VsoftLedgerAccountId = @VsoftLedgerAccountId
    WHERE RvID = @RvID
END  