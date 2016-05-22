create function dbo.Distance( @lat1 float , @long1 float , @lat2 float , @long2 float)
returns float

as

begin

declare @DegToRad as float
declare @Ans as float
declare @Miles as float

set @DegToRad = 57.29577951
set @Ans = 0
set @Miles = 0

if @lat1 is null or @lat1 = 0 or @long1 is null or @long1 = 0 or @lat2 is
null or @lat2 = 0 or @long2 is null or @long2 = 0

begin

return ( @Miles )

end

set @Ans = SIN(@lat1 / @DegToRad) * SIN(@lat2 / @DegToRad) + COS(@lat1 / @DegToRad ) * COS( @lat2 / @DegToRad ) * COS(ABS(@long2 - @long1 )/@DegToRad)

set @Miles = 3959 * ATAN(SQRT(1 - SQUARE(@Ans)) / @Ans)

return ( @Miles * 1.60934 * 1000)

end