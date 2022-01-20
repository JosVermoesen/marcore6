CREATE PROCEDURE [spVsoftSuppliers_UpdateFull]
  @Id nvarchar(12),
  @A102 nvarchar(1),
  @A100 nvarchar(35),
  @Vs01 nvarchar(1),
  @A125 nvarchar(35),
  @A10c nvarchar(1),
  @A104 nvarchar(30),
  @A105 nvarchar(5),
  @A106 nvarchar(4),
  @A107 nvarchar(7),
  @A108 nvarchar(24),
  @V149 nvarchar(3),
  @A109 nvarchar(3),
  @V150 nvarchar(2),
  @Vs03 nvarchar(3),
  @A10a nvarchar(12),
  @Vs02 nvarchar(12),
  @V224 nvarchar(60),
  @V163 nvarchar(1),
  @V016 nvarchar(7),
  @V161 nvarchar(7),
  @A161 nvarchar(15),
  @A170 nvarchar(14),
  @V259 nvarchar(50),
  @V260 nvarchar(50),
  @A400 nvarchar(10),
  @V015 nvarchar(10),
  @V151 nvarchar(1),
  @V111 nvarchar(1),
  @Vs04 nvarchar(4),
  @V017 nvarchar(1),
  @V018 nvarchar(9),
  @V001 nvarchar(30),
  @V002 nvarchar(64),
  @V226 nvarchar(50),
  @V227 nvarchar(50),
  @V247 nvarchar(50),
  @V254 nvarchar(50),
  @Decv018 money,
  @V255 nvarchar(50),
  @V256 nvarchar(50),
  @V262 nvarchar(max)
AS
BEGIN
  SET NOCOUNT ON
  UPDATE VsoftSuppliers SET  
    Id = @Id,    
      A102 = @A102,
      A100 = @A100,
      Vs01 = @Vs01,
      A125 = @A125,
      A10c = @A10c,
      A104 = @A104,
      A105 = @A105,
      A106 = @A106,
      A107 = @A107,
      A108 = @A108,
      V149 = @V149,
      A109 = @A109,
      V150 = @V150,
      Vs03 = @Vs03,
      A10a = @A10a,
      Vs02 = @Vs02,
      V224 = @V224,
      V163 = @V163,
      V016 = @V016,
      V161 = @V161,
      A161 = @A161,
      A170 = @A170,
      V259 = @V259,
      V260 = @V260,
      A400 = @A400,
      V015 = @V015,
      V151 = @V151,
      V111 = @V111,
      Vs04 = @Vs04,
      V017 = @V017,
      V018 = @V018,
      V001 = @V001,
      V002 = @V002,
      V226 = @V226,
      V227 = @V227,
      V247 = @V247,
      V254 = @V254,
      Decv018 = @Decv018,
      V255 = @V255,
      V256 = @V256,
      V262 = @V262
    WHERE Id = @Id
END  