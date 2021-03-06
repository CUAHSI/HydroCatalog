USE [ODMCV]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[UnitsID] [int] NOT NULL,
	[UnitsName] [nvarchar](255) NOT NULL,
	[UnitsType] [nvarchar](50) NULL,
	[UnitsAbbreviation] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (302, N'decisiemens per centimeter', N'Electrical Conductivity', N'dS/cm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (303, N'micromoles per liter', N'Concentration', N'umol/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (304, N'Joules per square centimeter', N'Energy per Area', N'J/cm2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (305, N'millimeters per day', N'velocity', N'mm/day')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (306, N'parts per thousand', N'Concentration', N'ppth')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (307, N'megaliter', N'Volume', N'ML')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (308, N'Percent Saturation', N'Concentration', N'% Sat')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (309, N'pH Unit', N'Dimensionless', N'pH')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (310, N'millimeters per second', N'Velocity', N'mm/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (311, N'liters per hour', N'Flow', N'L/hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (1, N'percent', N'Dimensionless', N'%')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (2, N'degree', N'Angle', N'deg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (3, N'grad', N'Angle', N'grad')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (4, N'radian', N'Angle', N'rad')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (5, N'degree north', N'Angle', N'degN')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (6, N'degree south', N'Angle', N'degS')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (7, N'degree west', N'Angle', N'degW')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (8, N'degree east', N'Angle', N'degE')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (9, N'arcminute', N'Angle', N'arcmin')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (10, N'arcsecond', N'Angle', N'arcsec')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (11, N'steradian', N'Angle', N'sr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (12, N'acre', N'Area', N'ac')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (13, N'hectare', N'Area', N'ha')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (14, N'square centimeter', N'Area', N'cm2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (15, N'square foot', N'Area', N'ft2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (16, N'square kilometer', N'Area', N'km2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (17, N'square meter', N'Area', N'm2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (18, N'square mile', N'Area', N'mi2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (19, N'hertz', N'Frequency', N'Hz')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (20, N'darcy', N'Permeability', N'D')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (21, N'british thermal unit', N'Energy', N'BTU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (22, N'calorie', N'Energy', N'cal')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (23, N'erg', N'Energy', N'erg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (24, N'foot pound force', N'Energy', N'lbf ft')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (25, N'joule', N'Energy', N'J')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (26, N'kilowatt hour', N'Energy', N'kW hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (27, N'electronvolt', N'Energy', N'eV')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (28, N'langleys per day', N'Energy Flux', N'Ly/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (29, N'langleys per minute', N'Energy Flux', N'Ly/min')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (30, N'langleys per second', N'Energy Flux', N'Ly/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (31, N'megajoules per square meter per day', N'Energy Flux', N'MJ/m2 d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (32, N'watts per square centimeter', N'Energy Flux', N'W/cm2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (33, N'watts per square meter', N'Energy Flux', N'W/m2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (34, N'acre feet per year', N'Flow', N'ac ft/yr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (35, N'cubic feet per second', N'Flow', N'cfs')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (36, N'cubic meters per second', N'Flow', N'm3/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (37, N'cubic meters per day', N'Flow', N'm3/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (38, N'gallons per minute', N'Flow', N'gpm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (39, N'liters per second', N'Flow', N'L/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (40, N'million gallons per day', N'Flow', N'MGD')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (41, N'dyne', N'Force', N'dyn')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (42, N'kilogram force', N'Force', N'kgf')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (43, N'newton', N'Force', N'N')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (44, N'pound force', N'Force', N'lbf')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (45, N'kilo pound force', N'Force', N'kip')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (46, N'ounce force', N'Force', N'ozf')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (47, N'centimeter   ', N'Length', N'cm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (48, N'international foot', N'Length', N'ft')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (49, N'international inch', N'Length', N'in')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (50, N'international yard', N'Length', N'yd')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (51, N'kilometer', N'Length', N'km')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (52, N'meter', N'Length', N'm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (53, N'international mile', N'Length', N'mi')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (54, N'millimeter', N'Length', N'mm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (55, N'micron', N'Length', N'um')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (56, N'angstrom', N'Length', N'Å')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (57, N'femtometer', N'Length', N'fm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (58, N'nautical mile', N'Length', N'nmi')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (59, N'lumen', N'Light', N'lm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (60, N'lux', N'Light', N'lx')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (61, N'lambert', N'Light', N'La')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (62, N'stilb', N'Light', N'sb')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (63, N'phot', N'Light', N'ph')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (64, N'langley', N'Light', N'Ly')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (65, N'gram', N'Mass', N'g')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (66, N'kilogram', N'Mass', N'kg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (67, N'milligram', N'Mass', N'mg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (68, N'microgram', N'Mass', N'ug')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (69, N'pound mass (avoirdupois)', N'Mass', N'lb')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (70, N'slug', N'Mass', N'slug')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (71, N'metric ton', N'Mass', N'tonne')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (72, N'grain', N'Mass', N'grain')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (73, N'carat', N'Mass', N'car')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (74, N'atomic mass unit', N'Mass', N'amu')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (75, N'short ton', N'Mass', N'ton')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (76, N'BTU per hour', N'Power', N'BTU/hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (77, N'foot pound force per second', N'Power', N'lbf/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (78, N'horse power (shaft)', N'Power', N'hp')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (79, N'kilowatt', N'Power', N'kW')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (80, N'watt', N'Power', N'W')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (81, N'voltampere', N'Power', N'VA')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (82, N'atmospheres', N'Pressure/Stress', N'atm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (83, N'pascal', N'Pressure/Stress', N'Pa')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (84, N'inch of mercury', N'Pressure/Stress', N'inch Hg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (85, N'inch of water', N'Pressure/Stress', N'inch H2O')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (86, N'millimeter of mercury', N'Pressure/Stress', N'mm Hg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (87, N'millimeter of water', N'Pressure/Stress', N'mm H2O')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (88, N'centimeter of mercury', N'Pressure/Stress', N'cm Hg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (89, N'centimeter of water', N'Pressure/Stress', N'cm H2O')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (90, N'millibar', N'Pressure/Stress', N'mbar')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (91, N'pound force per square inch', N'Pressure/Stress', N'psi')
GO
print 'Processed 100 total records'
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (92, N'torr', N'Pressure/Stress', N'torr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (93, N'barie', N'Pressure/Stress', N'barie')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (94, N'meters per pixel', N'Resolution', N'meters per pixel')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (95, N'meters per meter', N'Scale', N'-')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (96, N'degree celsius', N'Temperature', N'degC')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (97, N'degree fahrenheit', N'Temperature', N'degF')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (98, N'degree rankine', N'Temperature', N'degR')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (99, N'degree kelvin', N'Temperature', N'degK')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (100, N'second', N'Time', N's')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (101, N'millisecond', N'Time', N'millisec')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (102, N'minute', N'Time', N'min')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (103, N'hour', N'Time', N'hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (104, N'day', N'Time', N'd')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (105, N'week', N'Time', N'week')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (106, N'month', N'Time', N'month')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (107, N'common year (365 days)', N'Time', N'yr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (108, N'leap year (366 days)', N'Time', N'leap yr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (109, N'Julian year (365.25 days)', N'Time', N'jul yr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (110, N'Gregorian year (365.2425 days)', N'Time', N'greg yr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (111, N'centimeters per hour', N'Velocity', N'cm/hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (112, N'centimeters per second', N'Velocity', N'cm/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (113, N'feet per second', N'Velocity', N'ft/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (114, N'gallons per day per square foot', N'Velocity', N'gpd/ft2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (115, N'inches per hour', N'Velocity', N'in/hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (116, N'kilometers per hour', N'Velocity', N'km/h')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (117, N'meters per day', N'Velocity', N'm/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (118, N'meters per hour', N'Velocity', N'm/hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (119, N'meters per second', N'Velocity', N'm/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (120, N'miles per hour', N'Velocity', N'mph')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (121, N'millimeters per hour', N'Velocity', N'mm/hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (122, N'nautical mile per hour', N'Velocity', N'knot')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (123, N'acre foot', N'Volume', N'ac ft')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (124, N'cubic centimeter', N'Volume', N'cc')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (125, N'cubic foot', N'Volume', N'ft3')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (126, N'cubic meter', N'Volume', N'm3')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (127, N'hectare meter', N'Volume', N'hec m')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (128, N'liter', N'Volume', N'L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (129, N'US gallon', N'Volume', N'gal')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (130, N'barrel', N'Volume', N'bbl')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (131, N'pint', N'Volume', N'pt')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (132, N'bushel', N'Volume', N'bu')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (133, N'teaspoon', N'Volume', N'tsp')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (134, N'tablespoon', N'Volume', N'tbsp')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (135, N'quart', N'Volume', N'qrt')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (136, N'ounce', N'Volume', N'oz')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (137, N'dimensionless', N'Dimensionless', N'-')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (138, N'mega joule', N'Energy', N'MJ')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (139, N'degrees minutes seconds', N'Angle', N'dddmmss')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (140, N'calories per square centimeter per day', N'Energy Flux', N'cal/cm2 d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (141, N'calories per square centimeter per minute', N'Energy Flux', N'cal/cm2 min')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (142, N'milliliters per square centimeter per day', N'Hyporheic flux', N'ml/cm2 d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (143, N'micromoles of photons per square meter per second', N'Photon Flux', N'umol/m2 s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (144, N'megajoules per square meter', N'Energy per Area', N'MJ/m2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (145, N'gallons per day', N'Flow', N'gpd')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (146, N'million gallons per month', N'Flow', N'MGM')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (147, N'million gallons per year', N'Flow', N'MGY')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (148, N'tons per day per foot', N'Mass flow per unit width', N'ton/d ft')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (149, N'lumens per square foot', N'Light Intensity', N'lm/ft2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (150, N'microeinsteins per square meter per second', N'Light Intensity', N'uE/m2 s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (151, N'alphas per meter', N'Light', N'a/m')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (152, N'microeinsteins per square meter', N'Light', N'uE/m2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (153, N'millimoles of photons per square meter', N'Light', N'mmol/m2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (154, N'absorbance per centimeter', N'Extinction/Absorbance', N'A/cm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (155, N'nanogram', N'Mass', N'ng')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (156, N'picogram', N'Mass', N'pg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (157, N'milliequivalents', N'Mass', N'meq')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (158, N'grams per square meter', N'Areal Density', N'g/m2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (159, N'milligrams per square meter', N'Areal Density', N'mg/m2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (160, N'micrograms per square meter', N'Areal Density', N'ug/m2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (161, N'grams per square meter per day', N'Areal Loading', N'g/m2 d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (162, N'grams per day', N'Loading', N'g/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (163, N'pounds per day', N'Loading', N'lb/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (164, N'pounds per mile', N'Loading', N'lb/mi')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (165, N'tons per day', N'Loading', N'ton/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (166, N'milligrams per cubic meter per day', N'Productivity', N'mg/m3 d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (167, N'milligrams per square meter per day', N'Productivity', N'mg/m2 d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (168, N'volts', N'Potential Difference', N'V')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (169, N'millivolts', N'Potential Difference', N'mV')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (170, N'kilopascal', N'Pressure/Stress', N'kPa')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (171, N'megapascal', N'Pressure/Stress', N'MPa')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (172, N'becquerel', N'Radioactivity', N'Bq')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (173, N'becquerels per gram', N'Radioactivity', N'Bq/g')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (174, N'curie', N'Radioactivity', N'Ci')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (175, N'picocurie', N'Radioactivity', N'pCi')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (176, N'ohm', N'Resistance', N'ohm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (177, N'ohm meter', N'Resistivity', N'ohm m')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (178, N'picocuries per gram', N'Specific Activity', N'pCi/g')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (179, N'picocuries per liter', N'Specific Activity', N'pCi/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (180, N'picocuries per milliliter', N'Specific Activity', N'pCi/ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (181, N'hour minute', N'Time', N'hhmm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (182, N'year month day', N'Time', N'yymmdd')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (183, N'year day (Julian)', N'Time', N'yyddd')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (184, N'inches per day', N'Velocity', N'in/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (185, N'inches per week', N'Velocity', N'in/week')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (186, N'inches per storm', N'Precipitation', N'in/storm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (187, N'thousand acre feet', N'Volume', N'10^3 ac ft')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (188, N'milliliter', N'Volume', N'ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (189, N'cubic feet per second days', N'Volume', N'cfs d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (190, N'thousand gallons', N'Volume', N'10^3 gal')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (191, N'million gallons', N'Volume', N'10^6 gal')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (192, N'microsiemens per centimeter', N'Electrical Conductivity', N'uS/cm')
GO
print 'Processed 200 total records'
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (193, N'practical salinity units ', N'Salinity', N'psu')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (194, N'decibel', N'Sound', N'dB')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (195, N'cubic centimeters per gram', N'Specific Volume', N'cm3/g')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (196, N'square meters per gram', N'Specific Surface Area ', N'm2/g')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (197, N'tons per acre foot', N'Concentration', N'ton/ac ft')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (198, N'grams per cubic centimeter', N'Concentration', N'g/cm3')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (199, N'milligrams per liter', N'Concentration', N'mg/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (200, N'nanograms per cubic meter', N'Concentration', N'ng/m3')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (201, N'nanograms per liter', N'Concentration', N'ng/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (202, N'grams per liter', N'Concentration', N'g/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (203, N'micrograms per cubic meter', N'Concentration', N'ug/m3')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (204, N'micrograms per liter', N'Concentration', N'ug/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (205, N'parts per million', N'Concentration', N'ppm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (206, N'parts per billion', N'Concentration', N'ppb')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (207, N'parts per trillion', N'Concentration', N'ppt')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (208, N'parts per quintillion', N'Concentration', N'ppqt')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (209, N'parts per quadrillion', N'Concentration', N'ppq')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (210, N'per mille', N'Concentration', N'%o')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (211, N'microequivalents per liter', N'Concentration', N'ueq/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (212, N'milliequivalents per liter', N'Concentration', N'meq/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (213, N'milliequivalents per 100 gram', N'Concentration', N'meq/100 g')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (214, N'milliosmols per kilogram', N'Concentration', N'mOsm/kg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (215, N'nanomoles per liter', N'Concentration', N'nmol/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (216, N'picograms per cubic meter', N'Concentration', N'pg/m3')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (217, N'picograms per liter', N'Concentration', N'pg/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (218, N'picograms per milliliter', N'Concentration', N'pg/ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (219, N'tritium units', N'Concentration', N'TU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (220, N'jackson turbidity units', N'Turbidity', N'JTU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (221, N'nephelometric turbidity units', N'Turbidity', N'NTU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (222, N'nephelometric turbidity multibeam unit', N'Turbidity', N'NTMU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (223, N'nephelometric turbidity ratio unit', N'Turbidity', N'NTRU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (224, N'formazin nephelometric multibeam unit', N'Turbidity', N'FNMU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (225, N'formazin nephelometric ratio unit', N'Turbidity', N'FNRU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (226, N'formazin nephelometric unit', N'Turbidity', N'FNU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (227, N'formazin attenuation unit', N'Turbidity', N'FAU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (228, N'formazin backscatter unit ', N'Turbidity', N'FBU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (229, N'backscatter units', N'Turbidity', N'BU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (230, N'attenuation units', N'Turbidity', N'AU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (231, N'platinum cobalt units', N'Color', N'PCU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (232, N'the ratio between UV absorbance at 254 nm and DOC level', N'Specific UV Absorbance', N'L/(mg DOC/cm)')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (233, N'billion colonies per day', N'Organism Loading', N'10^9 colonies/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (234, N'number of organisms per square meter', N'Organism Concentration', N'#/m2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (235, N'number of organisms per liter', N'Organism Concentration', N'#/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (236, N'number or organisms per cubic meter', N'Organism Concentration', N'#/m3')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (237, N'cells per milliliter', N'Organism Concentration', N'cells/ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (238, N'cells per square millimeter', N'Organism Concentration', N'cells/mm2')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (239, N'colonies per 100 milliliters', N'Organism Concentration', N'colonies/100 ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (240, N'colonies per milliliter', N'Organism Concentration', N'colonies/ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (241, N'colonies per gram', N'Organism Concentration', N'colonies/g')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (242, N'colony forming units per milliliter', N'Organism Concentration', N'CFU/ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (243, N'cysts per 10 liters', N'Organism Concentration', N'cysts/10 L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (244, N'cysts per 100 liters', N'Organism Concentration', N'cysts/100 L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (245, N'oocysts per 10 liters', N'Organism Concentration', N'oocysts/10 L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (246, N'oocysts per 100 liters', N'Organism Concentration', N'oocysts/100 L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (247, N'most probable number', N'Organism Concentration', N'MPN')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (248, N'most probable number per 100 liters', N'Organism Concentration', N'MPN/100 L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (249, N'most probable number per 100 milliliters', N'Organism Concentration', N'MPN/100 ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (250, N'most probable number per gram', N'Organism Concentration', N'MPN/g')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (251, N'plaque-forming units per 100 liters', N'Organism Concentration', N'PFU/100 L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (252, N'plaques per 100 milliliters', N'Organism Concentration', N'plaques/100 ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (253, N'counts per second', N'Rate', N'#/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (254, N'per day', N'Rate', N'1/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (255, N'nanograms per square meter per hour', N'Volatilization Rate', N'ng/m2 hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (256, N'nanograms per square meter per week', N'Volatilization Rate', N'ng/m2 week')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (257, N'count', N'Dimensionless', N'#')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (258, N'categorical', N'Dimensionless', N'code')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (259, N'absorbance per centimeter per mg/L of given acid ', N'Absorbance', N'100/cm mg/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (260, N'per liter', N'Concentration Ratio', N'1/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (261, N'per mille per hour', N'Sedimentation Rate', N'%o/hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (262, N'gallons per batch', N'Flow', N'gpb')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (263, N'cubic feet per barrel', N'Concentration', N'ft3/bbl')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (264, N'per mille by volume', N'Concentration', N'%o by vol')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (265, N'per mille per hour by volume', N'Sedimentation Rate', N'%o/hr by vol')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (266, N'micromoles', N'Amount', N'umol')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (267, N'tons of calcium carbonate per kiloton', N'Net Neutralization Potential', N'tCaCO3/Kt')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (268, N'siemens per meter', N'Electrical Conductivity', N'S/m')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (269, N'millisiemens per centimeter', N'Electrical Conductivity', N'mS/cm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (270, N'siemens per centimeter', N'Electrical Conductivity', N'S/cm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (271, N'practical salinity scale', N'Salinity', N'pss')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (272, N'per meter', N'Light Extinction', N'1/m')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (273, N'normal', N'Normality', N'N')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (274, N'nanomoles per kilogram', N'Concentration', N'nmol/kg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (275, N'millimoles per kilogram', N'Concentration', N'mmol/kg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (276, N'millimoles per square meter per hour', N'Areal Flux', N'mmol/m2 hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (277, N'milligrams per cubic meter per hour', N'Productivity', N'mg/m3 hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (278, N'milligrams per day', N'Loading', N'mg/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (279, N'liters per minute', N'Flow', N'L/min')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (280, N'liters per day', N'Flow', N'L/d')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (281, N'jackson candle units ', N'Turbidity', N'JCU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (282, N'grains per gallon', N'Concentration', N'gpg')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (283, N'gallons per second', N'Flow', N'gps')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (284, N'gallons per hour', N'Flow', N'gph')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (285, N'foot candle', N'Illuminance', N'ftc')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (286, N'fibers per liter', N'Concentration', N'fibers/L')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (287, N'drips per minute', N'Flow', N'drips/min')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (288, N'cubic centimeters per second', N'Flow', N'cm3/sec')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (289, N'colony forming units', N'Organism Concentration', N'CFU')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (290, N'colony forming units per 100 milliliter', N'Organism Concentration', N'CFU/100 ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (291, N'cubic feet per minute', N'Flow', N'cfm')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (292, N'ADMI color unit', N'Color', N'ADMI')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (293, N'percent by volume', N'Concentration', N'% by vol')
GO
print 'Processed 300 total records'
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (294, N'number of organisms per 500 milliliter', N'Organism Concentration', N'#/500 ml')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (295, N'number of organisms per 100 gallon', N'Organism Concentration', N'#/100 gal')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (296, N'grams per cubic meter per hour', N'Productivity', N'g/m3 hr')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (297, N'grams per minute', N'Loading', N'g/min')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (298, N'grams per second', N'Loading', N'g/s')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (299, N'million cubic feet', N'Volume', N'10^6 ft3')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (300, N'month year', N'Time', N'mmyy')
INSERT [dbo].[Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation]) VALUES (301, N'bar', N'Pressure', N'bar')
/****** Object:  Table [dbo].[TopicCategoryCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopicCategoryCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'Unknown', N'The topic category is unknown')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'farming', N'Data associated with agricultural production')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'biota', N'Data associated with biological organisms')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'boundaries', N'Data associated with boundaries')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'climatology/meteorology/atmosphere', N'Data associated with climatology, meteorology, or the atmosphere')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'economy', N'Data associated with the economy')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'elevation', N'Data associated with elevation')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'environment', N'Data associated with the environment')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'geoscientificInformation', N'Data associated with geoscientific information')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'health', N'Data associated with health')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'imageryBaseMapsEarthCover', N'Data associated with imagery, base maps, or earth cover')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'intelligenceMilitary', N'Data associated with intelligence or the military')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'inlandWaters', N'Data associated with inland waters')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'location', N'Data associated with location')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'oceans', N'Data associated with oceans')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'planningCadastre', N'Data associated with planning or cadestre')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'society', N'Data associated with society')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'structure', N'Data associated with structure')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'transportation', N'Data associated with transportation')
INSERT [dbo].[TopicCategoryCV] ([Term], [Definition]) VALUES (N'utilitiesCommunication', N'Data associated with utilities or communication')
/****** Object:  Table [dbo].[temp_VerticalDatumCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_VerticalDatumCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](150) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_VerticalDatumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The vertical datum is not known', N'rejected  ', N'E', CAST(0x00009944013A59D4 AS DateTime), N'This is a test', N'David Tarboton', N'david.tarboton@usu.edu', N'Do not accept this test')
INSERT [dbo].[temp_VerticalDatumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The vertical datum is unknown', N'rejected  ', N'O', CAST(0x00009944013A59D4 AS DateTime), N'This is a test', N'David Tarboton', N'david.tarboton@usu.edu', N'Do not accept this test')
INSERT [dbo].[temp_VerticalDatumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'NAVD83', N'North American Vertical Datum 1983', N'rejected  ', N'A', CAST(0x0000995300AB3B28 AS DateTime), N'We use Spatial Reference of NAD83/UTM Zone 18N', N'Jean Miller', N'jmiller@iagt.org', N'perhaps a couple of things to clarify
 
1) your NAD83/UTM Zone 18 N is a HORIZONTAL datum, not a vertical
 
2) there is no NAVD83, there is only a NAVD29 and NAVD88 and those are the only two VERTICAL datum we deal with.
 
Hope this helps')
INSERT [dbo].[temp_VerticalDatumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'NAD06', N'This is really junk it does not exist, but hey .........', N'rejected  ', N'A', CAST(0x0000995400EBC314 AS DateTime), N'Why not?', N'Michael Piasecki', N'mp29@drexel.edu', N'junk')
/****** Object:  Table [dbo].[temp_VariableNameCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_VariableNameCV](
	[Term] [nvarchar](150) NOT NULL,
	[Definition] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'H2O Flux', N'This is the vertical flux of water vapor', N'approved  ', N'E', CAST(0x0000993E00B87130 AS DateTime), N'to have a definition', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'H2O Flux', N'', N'approved  ', N'O', CAST(0x0000993E00B87130 AS DateTime), N'to have a definition', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'new term', N'', N'rejected  ', N'A', CAST(0x0000994300FFB16C AS DateTime), N'reason', N'jenny', N'halcyongoddess@gmail.com', N'no. just no.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, nitrate (NO3) nitrogen as NO3 changed', N'', N'approved  ', N'E', CAST(0x0000994401169148 AS DateTime), N'To test the system.  I will revert this change later', N'David Tarboton', N'david.tarboton@usu.edu', N'Yes accept this')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, nitrate (NO3) nitrogen as NO3', N'', N'approved  ', N'O', CAST(0x0000994401169148 AS DateTime), N'To test the system.  I will revert this change later', N'David Tarboton', N'david.tarboton@usu.edu', N'Yes accept this')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Depth', N'Depth below water surface', N'rejected  ', N'A', CAST(0x0000995300AC3E24 AS DateTime), N'We have a buoy that takes measurements at different depths below the water surface.', N'Jean Miller', N'jmiller@iagt.org', N'More specificity as to what is being measured, or what the depth is, needed.  Look at the Offset concept in ODM.  I think this captures what you want to do.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Discharge, daily average', N'', N'approved  ', N'D', CAST(0x0000995A017078E8 AS DateTime), N'Per the discussion today an averaging period should not be part of the VariableName.  TimeSupport and DataType convey this information.', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Temperature, air', N'', N'approved  ', N'D', CAST(0x0000995A017151B4 AS DateTime), N'Just use plain temperature with sample medium air', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Bulk electrical conductivity', N'', N'approved  ', N'A', CAST(0x0000995B00C1E9CC AS DateTime), N'Variable name for TDR soil bulk electrical conductivity measurement.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Carbon dioxide concentration', N'', N'approved  ', N'A', CAST(0x0000995B00C25CA4 AS DateTime), N'Variable name for carbon diaoxide concentration measured as voltage by the sensor.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Oxygen concentration', N'', N'approved  ', N'A', CAST(0x0000995B00C31824 AS DateTime), N'Variable name for oxygen concentration measured as voltage from an oxygen sensor.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'TDR waveform relative length', N'Time domain reflextometry, aparent length divided by probe length. Square root of dielectric.', N'approved  ', N'A', CAST(0x0000995B00C38FAC AS DateTime), N'Variable name for LA/L measurement of a TDR probe.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Volumetric water content', N'', N'approved  ', N'A', CAST(0x0000995B00C44B2C AS DateTime), N'Variable name for the soil moisture measurement of a TDR Probe.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Temperature as resistance', N'', N'approved  ', N'A', CAST(0x0000995B00F7B930 AS DateTime), N'Variable name for soil thermistor resistance.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'dust', N'the stuff that is everywhere', N'rejected  ', N'A', CAST(0x0000995F0110C934 AS DateTime), N'because ....', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'no')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'dust', N'stuff that is everywhere', N'approved  ', N'A', CAST(0x0000995F011178FC AS DateTime), N'becuase', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'dust', N'stuff that is everywhere', N'rejected  ', N'E', CAST(0x0000995F0111FC3C AS DateTime), N'this is nonsense', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'dust', N'stuff that is everywhere', N'rejected  ', N'O', CAST(0x0000995F0111FC3C AS DateTime), N'this is nonsense', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'dust', N'stuff that is everywhere', N'approved  ', N'D', CAST(0x0000995F0115CEC0 AS DateTime), N'nonense', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Sulfur, Organic', N'Organic Sulfur', N'approved  ', N'E', CAST(0x0000995F0116BA4C AS DateTime), N'correcting spelling', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Sulfur, rganic', N'', N'approved  ', N'O', CAST(0x0000995F0116BA4C AS DateTime), N'correcting spelling', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'dust', N'rrrgh', N'rejected  ', N'A', CAST(0x0000996000C09144 AS DateTime), N'mhhh', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'no')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Snow Water Equivalent', N'The depth of water if a snow cover is completely melted, expressed in units of depth, on a corresponding horizontal surface area.', N'approved  ', N'A', CAST(0x000099850156B340 AS DateTime), N'I''ve begun formatting a dataset to upload and have a variable name that is not currently in the directory (atleast to my knowledge). Snow water equivalent (SWE) is a measured variable that not in the list yet. If you could add it that would be great.', N'David Tarboton entered for Tony Meierbachtol', N'toby.meierbachtol@umontana.edu', N'Done')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Radiation, total PAR', N'Total Photosynthetically-Active Radiation', N'approved  ', N'D', CAST(0x00009992015BD618 AS DateTime), N'This is redundant with Radiation, incoming PAR', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Radiation, net PAR', N'Net Photosynthetically-Active Radiation', N'approved  ', N'E', CAST(0x00009992015C2F28 AS DateTime), N'Terminology changed for consistency with other PAR variables', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Radiation, net photosynthetically-active', N'Net Photosynthetically-Active Radiation', N'approved  ', N'O', CAST(0x00009992015C2F28 AS DateTime), N'Terminology changed for consistency with other PAR variables', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Battery voltage, internal', N'The voltage of the internal lithium battery for a datalogger or sensor.  Often used to maintain the time when no external battery is connected.', N'rejected  ', N'A', CAST(0x000099B201746C3C AS DateTime), N'To store instrumentational data', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'We suggest you just use "battery voltage" for this and distinguish which battery in the method description associated with corresponding data values.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Temperature, internal', N'The internal temperature of a datalogger or sensor.', N'rejected  ', N'A', CAST(0x000099B20174D35C AS DateTime), N'To store instrumentational data', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'We suggest you use just temperature for this and indicate which temperature as part of the method.  Feel free to email me if you have strong counter opinions.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Colored Dissolved Organic Matter', N'', N'rejected  ', N'A', CAST(0x000099B300CDBF18 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'Please provide a definition for what this is so we can consider including it.  I do not know what it is.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Carbon to Nitrogen molar ratio', N'C:N (molar)', N'approved  ', N'A', CAST(0x000099B300CE3B50 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrate/Nitrite', N'Nitrate/Nitrite (micrograms of nitrogen per liter)', N'rejected  ', N'A', CAST(0x000099B300CE6B5C AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'Please see other Nitrogen variables such as "Nitrogen, nitrite (NO2) + nitrate (NO3) nitrogen as N".  Is this what you are intending.  I am concerned that "Nitrate/Nitrite" is not specific enough, but adding to the definition with units does not really clarify.  Can you help in working through all these chemical variable definitions to get them right?  Is there a reference or source for these that we should be using, rather than addressing one at a time?')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, Dissolved Inorganic', N'Dissolved inorganic nitrogen (micrograms of nitrogen per liter)', N'approved  ', N'A', CAST(0x000099B300CE958C AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, Total Dissolved', N'Total Dissolved Nitrogen', N'approved  ', N'A', CAST(0x000099B300CEC6C4 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, Dissolved Organic', N'Dissolved Organic Nitrogen', N'approved  ', N'A', CAST(0x000099B300CEEE9C AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen to Phosphorus molar ratio', N'Nitrogen to Phosphorus molar ratio', N'approved  ', N'A', CAST(0x000099B300CF0D14 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Primary Productivity', N'Primary Productivity', N'approved  ', N'A', CAST(0x000099B300CF3BF4 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Colored Dissolved Organic Matter', N'The concentration of colored dissolved organic matter (humic substances)', N'approved  ', N'A', CAST(0x000099B6000C7380 AS DateTime), N'add', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'H2O Flux', N'a defn', N'rejected  ', N'D', CAST(0x0000993E00B9A564 AS DateTime), N'to put it back to what it was', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, nitrate (NO3) nitrogen as NO3', N'The original definition', N'approved  ', N'E', CAST(0x000099440117D710 AS DateTime), N'Reverting back earlier change', N'David Tarboton', N'david.tarboton@usu.edu', N'Accept')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, nitrate (NO3) nitrogen as NO3 changed', N'', N'approved  ', N'O', CAST(0x000099440117D710 AS DateTime), N'Reverting back earlier change', N'David Tarboton', N'david.tarboton@usu.edu', N'Accept')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, Particulate', N'Particulate Nitrogen (micrograms of nitrogen per liter)', N'approved  ', N'A', CAST(0x000099B300CE0EC8 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Chlorophyllide a', N'Chlorophyllide a', N'approved  ', N'A', CAST(0x000099B300CF5940 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Chlorophyll c1 and c2', N'Chlorophyll c1 and c2', N'approved  ', N'A', CAST(0x000099B300CF7D94 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'Can you please expand the definition (I am accepting so do this as an edit)')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, Particulate', N'Particulate Nitrogen', N'approved  ', N'A', CAST(0x000099B300CF9F90 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'Can you please expand the definition (I am accepting so do this as an edit)')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Carbon to Nitrogen molar ratio', N'Carbon to Nitrogen molar ratio', N'rejected  ', N'A', CAST(0x000099B300CFC2B8 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'This is already there')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrate/Nitrite', N'Nitrate/Nitrite (micrograms of nitrogen per liter)', N'rejected  ', N'A', CAST(0x000099B300CFEBBC AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'Use "Nitrogen, nitrite (NO2) + nitrate (NO3) nitrogen as N"')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, Dissolved inorganic', N'Dissolved inorganic nitrogen', N'rejected  ', N'A', CAST(0x000099B300D00908 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'Use "Nitrogen, nitrite (NO2) + nitrate (NO3) nitrogen as N"')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, Total Dissolved', N'Total Dissolved Nitrogen', N'rejected  ', N'A', CAST(0x000099B300D028AC AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'Use "Nitrogen, nitrite (NO2) + nitrate (NO3) nitrogen as N"')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Peridinin', N'Peridinin', N'approved  ', N'A', CAST(0x000099B300D0659C AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'19''-Hexanoyloxyfucoxanthin', N'19''-Hexanoyloxyfucoxanthin', N'approved  ', N'A', CAST(0x000099B300D096D4 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Fucoxanthin', N'Fucoxanthin', N'approved  ', N'A', CAST(0x000099B300D0AAC0 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'9'' cis-Neoxanthin', N'9'' cis-Neoxanthin', N'approved  ', N'A', CAST(0x000099B300D0D298 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Diadino', N'Diadino', N'approved  ', N'A', CAST(0x000099B300D0E684 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Diadinoxanthin', N'Diadinoxanthin', N'approved  ', N'A', CAST(0x000099B300D110B4 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Antheraxanthin', N'Antheraxanthin', N'approved  ', N'A', CAST(0x000099B300D13184 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Monadoxanthin', N'Monadoxanthin', N'approved  ', N'A', CAST(0x000099B300D147C8 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Alloxanthin', N'Alloxanthin', N'approved  ', N'A', CAST(0x000099B300D16064 AS DateTime), N'', N'Rodney Guajardor', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Violaxanthin', N'Violaxanthin', N'approved  ', N'A', CAST(0x000099B300D176A8 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Lutein', N'Lutein', N'approved  ', N'A', CAST(0x000099B300D18E18 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Zeaxanthin', N'Zeaxanthin', N'approved  ', N'A', CAST(0x000099B300D1A45C AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'B-Carotene', N'B-Carotene', N'approved  ', N'A', CAST(0x000099B300D1C400 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Diatoxanthin', N'Diatoxanthin', N'approved  ', N'A', CAST(0x000099B300D1E020 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Chlorophyll a epimer', N'Chlorophyll a epimer', N'approved  ', N'A', CAST(0x000099B300D207F8 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Canthaxanthin', N'Canthaxanthin', N'approved  ', N'A', CAST(0x000099B300D23354 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Echinenone', N'Echinenone', N'approved  ', N'A', CAST(0x000099B300D24998 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Chlorophytes', N'Chlorophytes', N'approved  ', N'A', CAST(0x000099B300D26108 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Cryptophytes', N'Cryptophytes', N'approved  ', N'A', CAST(0x000099B300D281D8 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Cyanobacteria', N'Cyanobacteria', N'approved  ', N'A', CAST(0x000099B300D29498 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Diatoms', N'Diatoms', N'approved  ', N'A', CAST(0x000099B300D2A500 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Dinoflagellates', N'Dinoflagellates', N'approved  ', N'A', CAST(0x000099B300D2BB44 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Chlorophyll a allomer', N'Chlorophyll a allomer', N'approved  ', N'A', CAST(0x000099B300D2F5DC AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Chlorophyll Fluorescence', N'Chlorophyll Fluorescence', N'approved  ', N'A', CAST(0x000099B300D3DDE4 AS DateTime), N'', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Identifier', N'Identifier for an object such as a datalogger, datalogger program or a site. Object being identified to be specified in methods.', N'rejected  ', N'A', CAST(0x000099BA000BF298 AS DateTime), N'could not find anything resembling an ID field in the variablenamescv', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'Handled using the variable "recorder code" that has just been added.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Counter', N'Counter for samples from an automated water sampler or similar. Phenomenon being counted to be specified in methods.', N'rejected  ', N'A', CAST(0x000099BA000CE400 AS DateTime), N'as above', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'In cases such as this I think that the variable should refer to the phenomenon being counted and the units should be count (unitid=257).  Can this work for you.  If the variable that you want to count is not in ODM then it should be added.  Email me if you want to discuss this more.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'water level', N'water level relative to datum (like NGVD 1929)', N'approved  ', N'A', CAST(0x000099BC00948900 AS DateTime), N'so i can code groundwater levels without using gage height variable and it can be obvious to users what the measure is', N'kathleen mckee', N'katmckee@ufl.edu', N'OK Done - see expanded definition I used.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Channel velocity', N'The velocity of the water flowing through a channel', N'approved  ', N'A', CAST(0x000099C20059F358 AS DateTime), N'Parameter for measuring velocity in a stream/irrigation channel/pipe so that flows can then be calculated', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'We accept this as a general variable "velocity" that can be applied to channel and or pipe.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Temperature, water', N'', N'approved  ', N'D', CAST(0x0000995A0171A290 AS DateTime), N'Just use temperature with sample medium water', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Battery voltage', N'The battery voltage of a datalogger or sensing system, often recorded as an indicator of data reliability', N'approved  ', N'A', CAST(0x0000995A017232B4 AS DateTime), N'This is necessary', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Signal-to-noise ratio', N'Signal-to-noise ratio (often abbreviated SNR or S/N) is an electrical engineering concept defined as the ratio of a signal power to the noise power corrupting the signal. The higher the ratio, the less obtrusive the background noise is.', N'approved  ', N'A', CAST(0x000099C1013CC5C0 AS DateTime), N'parameter for measuring instrumentation signal strengths', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Recorder code', N'A code used to identifier a data recorder.', N'approved  ', N'A', CAST(0x000099C20113BE3C AS DateTime), N'Australia Instrumentation monitoring request', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Program signature', N'A unique data recorder program identifier which is useful for knowing when the source code in the data recorder has been modified.', N'approved  ', N'A', CAST(0x000099C2011420AC AS DateTime), N'Australia Instrumentation monitoring request', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Watchdog error count', N'A counter which counts the number of total datalogger watchdog errors', N'approved  ', N'A', CAST(0x000099C20114831C AS DateTime), N'Australia Instrumentation Network Monitoring request', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Table overrun error count', N'A counter which counts the number of datalogger table overrun errors', N'approved  ', N'A', CAST(0x000099C20114F39C AS DateTime), N'Australian Instrumentation Network Monitoring request.', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Flash memory error count', N'A counter which counts the number of  datalogger flash memory errors', N'approved  ', N'A', CAST(0x000099C201154F04 AS DateTime), N'Australian Instrumentation Network monitoring request', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Low battery count', N'A counter of the number of times the battery voltage dropped below a minimum threshold', N'approved  ', N'A', CAST(0x000099C20115B624 AS DateTime), N'Australian Instrumentation Network monitoring request', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Container number', N'The identifying number for a water sampler container.', N'approved  ', N'A', CAST(0x000099C20116163C AS DateTime), N'Australian Instrumentation Network monitoring request', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Sequence number', N'A counter of events in a sequence', N'approved  ', N'A', CAST(0x000099C20116AC3C AS DateTime), N'Australian Instrumentation network monitoring request', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Latitude', N'Latitude', N'approved  ', N'A', CAST(0x000099C9009997EC AS DateTime), N'We''ve set a lat/long for center of Neuse River, but we are going to use actual Lat/Long as variables.  Possibly just a temporary solution.', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Longitude', N'Longitude', N'approved  ', N'A', CAST(0x000099C90099AF5C AS DateTime), N'We''ve set a lat/long for center of Neuse River, but we are going to use actual Lat/Long as variables.  Possibly just a temporary solution.', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'TestTerm', N'Test', N'approved  ', N'A', CAST(0x000099C9011B1970 AS DateTime), N'Test', N'Jeff Horsburgh', N'jeffh@cc.usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'TestTerm', N'Test', N'approved  ', N'D', CAST(0x000099C9011C39B8 AS DateTime), N'I was testing', N'Jeff Horsburgh', N'jeffh@cc.usu.edu', N'Ok to remove now I am done with test.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Longitude', N'Longitude', N'approved  ', N'A', CAST(0x000099CA00AD3C70 AS DateTime), N'We''ve set a lat/long for center of Neuse River, but we are going to use actual Lat/Long as variables.  Possibly just a temporary solution.', N'Rodney Guajardo', N'rodneyg@unc.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Phosphorus, total as P, filtered', N'Total Phosphorus as P, filtered sample', N'approved  ', N'A', CAST(0x000099EB0115B4F8 AS DateTime), N'Does not exist in the CV yet, but we are measuring it, so please add.', N'Amber Spackman', N'amspack@cc.usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Evapotranspiration, potential', N'The amount of water that could be evaporated and transpired if there was sufficient water available.', N'approved  ', N'A', CAST(0x000099FB01837704 AS DateTime), N'Different to evapotranspiration refer: http://en.wikipedia.org/wiki/Evapotranspiration', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'Good idea')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Leaf wetness', N'The effect of moisture settling on the surface of a leaf as a result of either condensation or rainfall.', N'approved  ', N'A', CAST(0x000099FC0003C21C AS DateTime), N'Not in ODM', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'Good idea')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Precipitation, intensity', N'Precipitation integrated over a time interval', N'rejected  ', N'A', CAST(0x000099FC00078C6C AS DateTime), N'To store rainfall intensity ie units of (mm/hr)', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'No. Use precipitation.  There are lots of quantities that can be expressed as cumulative over an interval or instantaneous.  In ODM this distinction is through datatype.  We do not want separate variables for each one. This concept applies to precipitation, evaporation, radiation etc.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Alkalinity, hydroxide as CaCO3', N'Hydroxide Alkalinity as calcium carbonate', N'approved  ', N'E', CAST(0x00009A7300AF7BD4 AS DateTime), N'Fix case', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Alkalinity, hydroxide as CaCo3', N'Hydroxide Alkalinity as calcium carbonate', N'approved  ', N'O', CAST(0x00009A7300AF7BD4 AS DateTime), N'Fix case', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Rain', N'The amount of rain at the measured period.', N'rejected  ', N'A', CAST(0x00009A7B00D48ED8 AS DateTime), N'This is different from water level which is usually used for depth and another variable is needed to measure the amount of rain.', N'James Kang', N'jkang@cs.umn.edu', N'It sounds like the existing term: Precipitation (definition: Precipitation such as rainfall. Should not be confused with settling.)
would meet your needs.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'External Battery', N'External battery is the battery for the datalogger that also actually powers the equipment.', N'rejected  ', N'A', CAST(0x00009A7B00E8C128 AS DateTime), N'The variable "battery" is not sufficient since it may mean either internal or external which is different.', N'James Kang', N'jkang@cs.umn.edu', N'Use the VariableName "Battery voltage" for all battery voltages.  We want to avoid having too much place information in the name.  We do not want this list to grow to internal, external, on top, underneath, adjacent etc.  Rather we suggest you describe the position of the sensor - such as internal and external in the method.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Nitrogen, ammonia (NH3) + ammonium (NH4)', N'see EPA method 350.1', N'approved  ', N'A', CAST(0x00009AA100F66684 AS DateTime), N'is in our Water Quality data for springs', N'kathleen mckee', N'katmckee@ufl.edu', N'The term: "Nitrogen, NH3 + NH4 as N" is already in the VariableNameCV.')
GO
print 'Processed 100 total records'
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Discharge volume', N'The volume of discharge passed through the cross-section of a channel', N'rejected  ', N'A', CAST(0x000099C2005DAD40 AS DateTime), N'Parameter for how much hourly runoff has passed through a stream gauge after a rainfall event', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'We have discharge in the list and also quite a nuber of units to go wiht it, among them m^3/d.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Volume', N'Volume. To quantify discharge or hydrograph volume or some other volume measurement.', N'approved  ', N'A', CAST(0x000099C201665B10 AS DateTime), N'Needed', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test1', N'Test1', N'rejected  ', N'A', CAST(0x000099C9011B3A40 AS DateTime), N'Test1', N'Jeff Horsburgh', N'jeffh@cc.usu.edu', N'Rejecting test term')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Vapor pressure', N'The pressure of a vapor in equilibrium with its non-vapor phases', N'approved  ', N'A', CAST(0x000099FB01857E28 AS DateTime), N'Not in ODM', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'Good idea')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Internal Battery', N'Internal battery is the small battery inside the equipment (e.g. inside the hydrolab there is a small battery).', N'rejected  ', N'A', CAST(0x00009A7B00E86F20 AS DateTime), N'The variable battery is not sufficient since this may mean either internal or external which is different.', N'James Kang', N'jkang@cs.umn.edu', N'Use the VariableName "Battery voltage" for all battery voltages.  We want to avoid having too much place information in the name.  We do not want this list to grow to internal, external, on top, underneath, adjacent etc.  Rather we suggest you describe the position of the sensor - such as internal and external in the method.')
INSERT [dbo].[temp_VariableNameCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Streamflow', N'The volume of water flowing past a fixed point.  Equivalent to discharge', N'approved  ', N'A', CAST(0x000099FC0075F3B4 AS DateTime), N'It is used commonly - see http://ga.water.usgs.gov/edu/measureflow.html', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
/****** Object:  Table [dbo].[temp_ValueTypeCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_ValueTypeCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[temp_Units]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_Units](
	[UnitsID] [int] NOT NULL,
	[UnitsName] [nvarchar](255) NOT NULL,
	[UnitsType] [nvarchar](50) NULL,
	[UnitsAbbreviation] [nvarchar](50) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'fake units', N'length', N'fu', N'approved  ', N'A', CAST(0x0000994300B077C8 AS DateTime), N'test of the CV web system', N'David Tarboton', N'david.tarboton@usu.edu', N'I am temporarily accepting this to see if the system works.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'fake area units', N'area', N'fu', N'approved  ', N'E', CAST(0x0000994300B26B00 AS DateTime), N'This is a test of how to change the units.', N'David Tarboton', N'david.tarboton@usu.edu', N'Still testing.  I am accepting this change - but modifying it a but ')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'fake units', N'length', N'fu', N'approved  ', N'O', CAST(0x0000994300B26B00 AS DateTime), N'This is a test of how to change the units.', N'David Tarboton', N'david.tarboton@usu.edu', N'Still testing.  I am accepting this change - but modifying it a but ')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'fake units of area', N'area', N'fu', N'approved  ', N'D', CAST(0x0000994300B36DFC AS DateTime), N'Now I am testing the ability to delete this record.', N'David Tarboton', N'david.tarboton@usu.edu', N'Yes we want to delete this to get things cleaned up.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'feet', N'Length', N'ft', N'rejected  ', N'A', CAST(0x0000994C00B1DADC AS DateTime), N'Because it should be there.  I am surprised that it is not.  Michael this is your first chance to approve something.', N'David Tarboton', N'david.tarboton@usu.edu', N'Use International Foot, unit ID 48')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'volts', N'Potential Difference', N'V', N'rejected  ', N'A', CAST(0x0000995B00B978DC AS DateTime), N'Units for datalogger panel voltage.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'No - this is already there as item 168')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'ohm', N'Resistance', N'ohm', N'rejected  ', N'A', CAST(0x0000995B00BA9924 AS DateTime), N'Units to measure temperature as electrical resistance from a thermocouple.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'No - this is already there as item 176')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'milivolts', N'Potential Difference', N'mV', N'rejected  ', N'A', CAST(0x0000995B00BAF360 AS DateTime), N'Units to measure carbon dioxide concentration as voltage.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'No - this is already there as item 169')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'decisiements per centimeter', N'Conductivity', N'dS/cm', N'rejected  ', N'A', CAST(0x0000995B00BB48EC AS DateTime), N'Units to measure bulk electrical conductivity of soil.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'Reject for Typo - I submitted one with correct spelling')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'decisiemens per centimeter', N'Electrical Conductivity', N'dS/cm', N'approved  ', N'A', CAST(0x0000995B0119C7F0 AS DateTime), N'Needed for TDR soil moisture measurements', N'David Tarboton', N'david.tarboton@usu.edu', N'I''m am testing that the issue David found with not being able to add items to the Units table is fixed.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (269, N'millisiemens per centimeter', N'Electrical Conductivity', N'mS/cm', N'approved  ', N'E', CAST(0x0000995B011DBA18 AS DateTime), N'"Conductivity" applies to things other than Electrical, such as "Hydraulic" conductivity', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (269, N'millisiemens per centimeter', N'Conductivity', N'mS/cm', N'approved  ', N'O', CAST(0x0000995B011DBA18 AS DateTime), N'"Conductivity" applies to things other than Electrical, such as "Hydraulic" conductivity', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (268, N'siemens per meter', N'Electrical Conductivity', N'S/m', N'rejected  ', N'E', CAST(0x0000995B01213CEC AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'muddled up')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (268, N'siemens per meter', N'Conductivity', N'S/m', N'rejected  ', N'O', CAST(0x0000995B01213CEC AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'muddled up')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (270, N'siemens per centimeter', N'Electrical Conductivity', N'S/cm', N'rejected  ', N'E', CAST(0x0000995B01216014 AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'muddled up')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (270, N'siemens per centimeter', N'Conductivity', N'S/cm', N'rejected  ', N'O', CAST(0x0000995B01216014 AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'muddled up')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (192, N'microsiemens per centimeter', N'Electrical Conductivity', N'uS/cm', N'approved  ', N'E', CAST(0x0000995B01217E8C AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (192, N'microsiemens per centimeter', N'Conductivity', N'uS/cm', N'approved  ', N'O', CAST(0x0000995B01217E8C AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (268, N'siemens per meter', N'Electrical Conductivity', N'S/m', N'approved  ', N'E', CAST(0x0000995B0122CDB4 AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (268, N'siemens per meter', N'Conductivity', N'S/m', N'approved  ', N'O', CAST(0x0000995B0122CDB4 AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (270, N'siemens per centimeter', N'Electrical Conductivity', N'S/cm', N'approved  ', N'E', CAST(0x0000995B0122F460 AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (270, N'siemens per centimeter', N'Conductivity', N'S/cm', N'approved  ', N'O', CAST(0x0000995B0122F460 AS DateTime), N'specificity', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (302, N'a test new unit', N'length', N'atnu', N'rejected  ', N'A', CAST(0x0000995B0123DFEC AS DateTime), N'to see if we can add a new unit', N'David Tarboton', N'david.tarboton@usu.edu', N'because it is a test')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (303, N'ducks feet', N'length', N'df', N'approved  ', N'A', CAST(0x0000995F00E5E138 AS DateTime), N'to test the capability to add new units', N'David Tarboton', N'david.tarboton@usu.edu', N'accept temporarily - to delete later')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (303, N'ducks feet', N'length', N'df', N'approved  ', N'D', CAST(0x0000995F00E69358 AS DateTime), N'this was a test', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (303, N'web feet', N'length', N'wf', N'rejected  ', N'A', CAST(0x0000995F0100D1B4 AS DateTime), N'a test of the system', N'David Tarboton', N'david.tarboton@usu.edu', N'Reject')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (303, N'micromoles per liter', N'Concentration', N'umol / l', N'approved  ', N'A', CAST(0x0000998600884334 AS DateTime), N'our sensor raw data is in micromoles per liter', N'kathleen mckee', N'katmckee@ufl.edu', N'Done (note I changed the L to upper case for consistency)')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (304, N'Joules per square centimeter', N'Solar Radiation', N'J/cm2', N'approved  ', N'A', CAST(0x0000999200ADB650 AS DateTime), N'It is a unit used in Sevilleta', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (144, N'megajoules per square meter', N'Energy per Area', N'MJ/m2', N'approved  ', N'E', CAST(0x00009994016BD6F8 AS DateTime), N'To have greater generality', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (144, N'megajoules per square meter', N'Solar Radiation', N'MJ/m2', N'approved  ', N'O', CAST(0x00009994016BD6F8 AS DateTime), N'To have greater generality', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (304, N'Joules per square centimeter', N'Energy per Area', N'J/cm2', N'approved  ', N'E', CAST(0x00009994016C05D8 AS DateTime), N'greater generality', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (304, N'Joules per square centimeter', N'Solar Radiation', N'J/cm2', N'approved  ', N'O', CAST(0x00009994016C05D8 AS DateTime), N'greater generality', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (305, N'inches/hour', N'precipitation', N'in/hr', N'approved  ', N'A', CAST(0x000099A700B37E64 AS DateTime), N'typically used', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (305, N'millimeter per hour', N'precipitation', N'mm/hr', N'approved  ', N'A', CAST(0x000099A700B3B7D0 AS DateTime), N'need Si units also for this', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (305, N'inches per day', N'precipitation', N'in/day', N'approved  ', N'A', CAST(0x000099A700B3E32C AS DateTime), N'some as previous', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (305, N'millimeter per day', N'precipitation', N'mm/day', N'approved  ', N'A', CAST(0x000099A700B40E88 AS DateTime), N'same as before', N'Michael Piasecki', N'Michael.Piasecki@drexel.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (305, N'inches/hour', N'precipitation', N'in/hr', N'approved  ', N'D', CAST(0x000099A700E13A98 AS DateTime), N'This is repetitive of 115', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (305, N'millimeters per hour', N'precipitation', N'mm/hr', N'approved  ', N'D', CAST(0x000099A700E1F744 AS DateTime), N'Repetitive', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (2, N'degree', N'Temperature', N'deg', N'rejected  ', N'E', CAST(0x0000993E00B7591C AS DateTime), N'to be different - as a test', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (2, N'degree', N'Angle', N'deg', N'rejected  ', N'O', CAST(0x0000993E00B7591C AS DateTime), N'to be different - as a test', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (306, N'Parts Per Thousand', N'Concentration', N'ppt', N'approved  ', N'A', CAST(0x000099AE00CB5200 AS DateTime), N'Salinity unit', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'OK - abbreviation changed to ppth to avoid clash with parts per trillion that is already there with ppt')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (306, N'Percent Saturation', N'', N'% Sat', N'rejected  ', N'A', CAST(0x000099AE00CBCAB4 AS DateTime), N'YSI dissolved oxygen', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'I will be entering - but due to a glitch in our system need to reject.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (306, N'Percent Full Scale', N'', N'% FS', N'rejected  ', N'A', CAST(0x000099AE00CBFBEC AS DateTime), N'YSI Chlorophyll fluorescence', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'Just use percent')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (306, N'molar', N'', N'molar', N'rejected  ', N'A', CAST(0x000099AE00CC6B40 AS DateTime), N'Carbon to nitrogen;
Nitrogen to Phosphorus', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'use dimensionless for these ratios')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (306, N'Milligrams of Carbon per Liter', N'Concentration', N'mg C L-1', N'rejected  ', N'A', CAST(0x000099AE00CCB064 AS DateTime), N'Dissolved Inorganic Carbon', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'Just use milligrams per liter.  carbon is specified in variable name (Carbon, dissolved inorganic)')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (306, N'micrograms of nitrogen per liter', N'Concentration', N'µg N L-1', N'rejected  ', N'A', CAST(0x000099AE00CD4088 AS DateTime), N'Nitrate/Nitrite;Ammonium;Dissolved inorganic nitrogen;Total Dissolved Nitrogen;Dissolved Organic Nitrogen', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'Just use micrograms per liter.  Other info specified by variable')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (306, N'Micrograms of Phosphorus per liter', N'Concentration', N'µg P L-1', N'rejected  ', N'A', CAST(0x000099AE00CD79F4 AS DateTime), N'Orthosphosphate', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'just use micrograms per liter')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (306, N'Milligrams of Carbon per meter cubed per hour', N'Concentration', N'mgC m-3 h-1', N'rejected  ', N'A', CAST(0x000099AE00CDCF80 AS DateTime), N'Primary Productivity', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'Just use milligrams per cubic meter per hour')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (307, N'megaliter', N'Volume', N'ML', N'approved  ', N'A', CAST(0x000099B2016092FC AS DateTime), N'Used to measure runoff', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (308, N'MyUnit', N'Length', N'MyU', N'rejected  ', N'A', CAST(0x000099B500BBFC38 AS DateTime), N'I feel really good about this!', N'David Maidment', N'maidment@mail.utexas.edu', N'Good to see you exercising this - but it is not specific enough to include.  (Dave from Scripps)')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (308, N'Percent Saturation', N'Concentration', N'% Sat', N'approved  ', N'A', CAST(0x000099B60008F304 AS DateTime), N'to represent DO', N'Rodney Guajardo', N'guajardo@email.unc.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (309, N'pH Unit', N'Dimensionless', N'pH', N'approved  ', N'A', CAST(0x000099CA007F9EB4 AS DateTime), N'pH needs VariableUnitsName in order for ODM Dataloader to work', N'Rodney Guajardo', N'rodneyg@unc.edu', N'ok')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (310, N'millimeters per second', N'Velocity', N'mm/s', N'approved  ', N'A', CAST(0x000099F10172DDCC AS DateTime), N'to measure stream velocity', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (311, N'foo', N'bar', N'foobar', N'rejected  ', N'A', CAST(0x00009A2400E7C2DC AS DateTime), N'Please ignore. This is a website test.', N'Kim Schreuders', N'kim.schreuders@usu.edu', N'Cleaning out')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (311, N'liters per hour', N'Flow', N'L/hr', N'approved  ', N'A', CAST(0x00009A2A013E66F0 AS DateTime), N'to measure flow', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (312, N'inches per hour', N'Precipitation', N'in / hr', N'rejected  ', N'A', CAST(0x00009A4601224948 AS DateTime), N'only other precip variables are mm/day and inches per storm.  I also want to add inches per day. There are 2 velocity variables that are inches per day and inches per week. How will this be resolved with precipitation variables? thanks!', N'kathleen mckee', N'katmckee@ufl.edu', N'Just use the in/hr velocity unit.  We are interpreting velocity and precipitation rate as the same.  The exception is storm precipitation which has unit type of precipitation.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (312, N'inches per day', N'Precipitation', N'in / day', N'rejected  ', N'A', CAST(0x00009A4601229B50 AS DateTime), N'Need appropriate Precipitation units...', N'Kathleen', N'katmckee@ufl.edu', N'Jus use the inches per day with Units Type velocity.  We are treating precipitation rate as the same as velocity.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (305, N'millimeters per day', N'velocity', N'mm/day', N'approved  ', N'E', CAST(0x00009A46012A7C1C AS DateTime), N'Change type to velocity for consistency with others', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (143, N'micromoles of photons per square meter per second', N'Photon Flux', N'umol/m2 s', N'rejected  ', N'E', CAST(0x00009ACC000A6C5C AS DateTime), N'MJ/m2', N'celestino ruggiero', N'cruggier@unina.it', N'See comment on similar request.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (143, N'micromoles of photons per square meter per second', N'Photon Flux', N'umol/m2 s', N'rejected  ', N'O', CAST(0x00009ACC000A6C5C AS DateTime), N'MJ/m2', N'celestino ruggiero', N'cruggier@unina.it', N'See comment on similar request.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (143, N'micromoles of photons per square meter per second', N'Photon Flux', N'umol/m2 s', N'rejected  ', N'E', CAST(0x00009ACC000ABC0C AS DateTime), N'conversion to MJ/m2', N'celestino ruggiero', N'cruggier@unina.it', N'I do not understand what change you are asking for.  Both Original and New entries are the same in your request.  Please send email to me explaining what you need. There is a separate unit (ID=144) that is MJ/m2.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (143, N'micromoles of photons per square meter per second', N'Photon Flux', N'umol/m2 s', N'rejected  ', N'O', CAST(0x00009ACC000ABC0C AS DateTime), N'conversion to MJ/m2', N'celestino ruggiero', N'cruggier@unina.it', N'I do not understand what change you are asking for.  Both Original and New entries are the same in your request.  Please send email to me explaining what you need. There is a separate unit (ID=144) that is MJ/m2.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (31, N'megajoules per square meter per day', N'Energy Flux', N'MJ/m2 d', N'rejected  ', N'E', CAST(0x00009AF70039849C AS DateTime), N'from kilowatt per m2 per day to mega joule per m2 per day', N'khaled', N'khaled_moneim@yahoo.com', N'There is no difference between what you have proposed and what is in the vocabulary.  Please email me if you want to clarify what your request is.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (31, N'megajoules per square meter per day', N'Energy Flux', N'MJ/m2 d', N'rejected  ', N'O', CAST(0x00009AF70039849C AS DateTime), N'from kilowatt per m2 per day to mega joule per m2 per day', N'khaled', N'khaled_moneim@yahoo.com', N'There is no difference between what you have proposed and what is in the vocabulary.  Please email me if you want to clarify what your request is.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (60, N'lux', N'Light', N'lx', N'rejected  ', N'E', CAST(0x00009B340071EC74 AS DateTime), N'I need a help! I know light intensity in growth chamber in luxes.
Can I and using which formula convert it in uE/m2 s ?', N'Snjezana Keresa', N'skeresa@agr.hr', N'lux is a measurement of light (already in the CV with ID=60), microEinsteins per sq. meter per second (already in the CV with ID=150) is a measurement of the rate of light.  They are sometimes equated, but for a more complete discussion, see: http://home.comcast.net/~cerny/pub/einsteins.html.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (60, N'lux', N'Light', N'lx', N'rejected  ', N'O', CAST(0x00009B340071EC74 AS DateTime), N'I need a help! I know light intensity in growth chamber in luxes.
Can I and using which formula convert it in uE/m2 s ?', N'Snjezana Keresa', N'skeresa@agr.hr', N'lux is a measurement of light (already in the CV with ID=60), microEinsteins per sq. meter per second (already in the CV with ID=150) is a measurement of the rate of light.  They are sometimes equated, but for a more complete discussion, see: http://home.comcast.net/~cerny/pub/einsteins.html.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (303, N'fake feet', N'length', N'ff', N'rejected  ', N'A', CAST(0x0000995F010DCD24 AS DateTime), N'a test of the system', N'David Tarboton', N'david.tarboton@usu.edu', N'Reject')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (305, N'millimeters per day', N'precipitation', N'mm/day', N'approved  ', N'O', CAST(0x00009A46012A7C1C AS DateTime), N'Change type to velocity for consistency with others', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (96, N'degree celsius', N'Temperature', N'degC', N'approved  ', N'E', CAST(0x00009BB900973EC0 AS DateTime), N'shouldn''t this be celsius rather than celcius?', N'Jeff Horsburgh', N'jeff.horsburgh@usu.edu', N'Yes of course')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (96, N'degree celcius', N'Temperature', N'degC', N'approved  ', N'O', CAST(0x00009BB900973EC0 AS DateTime), N'shouldn''t this be celsius rather than celcius?', N'Jeff Horsburgh', N'jeff.horsburgh@usu.edu', N'Yes of course')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (153, N'millimoles of photons per square meter', N'Light', N'mmol/m2', N'approved  ', N'E', CAST(0x0000996000529CD4 AS DateTime), N'I need to convert my project data', N'Behnam Kamkar', N'behnamkamkar@yahoo.com', N'Your request entered the system as an edit, but I could not see any difference between what was there previously and what you are requesting.  Accepting this does not actually change anything.')
INSERT [dbo].[temp_Units] ([UnitsID], [UnitsName], [UnitsType], [UnitsAbbreviation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (153, N'millimoles of photons per square meter', N'Light', N'mmol/m2', N'approved  ', N'O', CAST(0x0000996000529CD4 AS DateTime), N'I need to convert my project data', N'Behnam Kamkar', N'behnamkamkar@yahoo.com', N'Your request entered the system as an edit, but I could not see any difference between what was there previously and what you are requesting.  Accepting this does not actually change anything.')
/****** Object:  Table [dbo].[temp_TopicCategoryCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_TopicCategoryCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_TopicCategoryCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The topic category is not known', N'rejected  ', N'E', CAST(0x00009944013BE394 AS DateTime), N'another test', N'DGT', N'david.tarboton@gmail.com', N'reject this')
INSERT [dbo].[temp_TopicCategoryCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The topic category is unknown', N'rejected  ', N'O', CAST(0x00009944013BE394 AS DateTime), N'another test', N'DGT', N'david.tarboton@gmail.com', N'reject this')
/****** Object:  Table [dbo].[temp_SpatialReferences]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_SpatialReferences](
	[SpatialReferenceID] [int] NOT NULL,
	[SRSID] [int] NOT NULL,
	[SRSName] [nvarchar](255) NULL,
	[IsGeographic] [bit] NOT NULL,
	[Notes] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (6, 26705, N'NAD27 / UTM zone 5N', 0, N'', N'rejected  ', N'D', CAST(0x0000994300A71FFC AS DateTime), N'because', N'jen', N'halcyongoddess@gmail.com', N'asdf')
INSERT [dbo].[temp_SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (9, 26708, N'NAD27 / UTM zone 8N', 0, N'', N'approved  ', N'E', CAST(0x0000994300AA1D38 AS DateTime), N'because', N'jenny', N'halcyongoddess@gmail.com', N'bhlbjlbjkbkl')
INSERT [dbo].[temp_SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (9, 26708, N'NAD27 / UTM zone 8N', 0, N'', N'approved  ', N'O', CAST(0x0000994300AA1D38 AS DateTime), N'because', N'jenny', N'halcyongoddess@gmail.com', N'bhlbjlbjkbkl')
INSERT [dbo].[temp_SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (225, 33, N'GDA94 / NSW Lambert', 0, N'Datum Name: Geocentric Datum of Australia 1994 Area of Use: Australia - New South Wales (NSW). Datum Origin: ITRF92 at epoch 1994.0  Ellipsoid Name: GRS 1980 Data Source: EPSG', N'approved  ', N'A', CAST(0x00009A760157C8FC AS DateTime), N'Not in database.  Also the SRS ID is actually 3308.  The web entry system would not allow numbers greater than 2 digits in both ie and firefox.', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'Added.')
/****** Object:  Table [dbo].[temp_SampleTypeCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_SampleTypeCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_SampleTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'No Sample', N'Sample not submitted to lab', N'approved  ', N'A', CAST(0x0000995300ABABA8 AS DateTime), N'We do not send samples to a lab.', N'Jean Miller', N'jmiller@iagt.org', N'This is a good idea.  I tweaked the wording a bit.  This can also be accommodated by leaving the SampleID NULL.')
INSERT [dbo].[temp_SampleTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'', N'???????????: ???????????????? ??? ?????????, ???????? free, ???????? ???? ??, ???? ??? ??????? ? ????????, ???????? ????????? ??? ???????????, ??? ????????? ????, ???? ??? ??????????, ???????? ??????? ??????. ???? chat.24lux.ru', N'submitted ', N'A', CAST(0x00009F9100385C20 AS DateTime), N'???????????: ???????????????? ??? ?????????, ???????? free, ???????? ???? ??, ???? ??? ??????? ? ????????, ???????? ????????? ??? ???????????, ??? ????????? ????, ???? ??? ??????????, ???????? ??????? ??????. ???? chat.24lux.ru', N'anzelliiu', N'iimkpbianpozhf@gmail.com', NULL)
/****** Object:  Table [dbo].[temp_SampleMediumCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_SampleMediumCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_SampleMediumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Other', N'Sample medium not relavent in the context of the measurement', N'approved  ', N'A', CAST(0x0000995B00B71E84 AS DateTime), N'Medium for datalogger panel voltage and datalogger internal temperature.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'OK')
INSERT [dbo].[temp_SampleMediumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Snow', N'Sample taken from snow', N'approved  ', N'A', CAST(0x0000995B00B75A48 AS DateTime), N'Medium for snow depth.', N'Kim Schreuders', N'kimas@cc.usu.edu', N'OK')
INSERT [dbo].[temp_SampleMediumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Surface Water', N'Observation in, of or sample taken from surface water such as a stream, river, lake, pond, reservoir, ocean, etc.', N'approved  ', N'E', CAST(0x0000995F00E83488 AS DateTime), N'To be more specific', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_SampleMediumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Surface Water', N'Sample taken from surface water such as a stream, river, lake, pond, reservoir, ocean, etc.', N'approved  ', N'O', CAST(0x0000995F00E83488 AS DateTime), N'To be more specific', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_SampleMediumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Not Relevant', N'Sample medium is not relevant to the context of the variable', N'approved  ', N'A', CAST(0x00009A6601009BCC AS DateTime), N'There are some variables for which sample medium is not relevant.', N'Teklu Tesfa', N'tesfa@cc.usu.edu', N'OK')
INSERT [dbo].[temp_SampleMediumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Pore water', N'The water in soil pores', N'approved  ', N'A', CAST(0x00009B1800D9056C AS DateTime), N'To test the system', N'David Tarboton', N'david.tarboton@gmail.com', N'OK')
INSERT [dbo].[temp_SampleMediumCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Pore water', N'The water in soil pores', N'approved  ', N'D', CAST(0x00009B1800DA9E68 AS DateTime), N'Test - we do not really want it', N'David Tarboton', N'DTARB@cc.usu.edu', N'OK')
/****** Object:  Table [dbo].[temp_QualityControlLevels]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_QualityControlLevels](
	[QualityControlLevelID] [int] NOT NULL,
	[Definition] [nvarchar](255) NULL,
	[Explanation] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (2, N'', N'Derived products require scientific and technical interpretation and include multiple-sensor data. An example might be basin average precipitation derived from rain gages using an interpolation procedure.', N'approved  ', N'E', CAST(0x0000994300E2A130 AS DateTime), N'reason', N'jen', N'halcyongoddess@gmail.com', N'reason')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (2, N'Derived products', N'Derived products require scientific and technical interpretation and include multiple-sensor data. An example might be basin average precipitation derived from rain gages using an interpolation procedure.', N'approved  ', N'O', CAST(0x0000994300E2A130 AS DateTime), N'reason', N'jen', N'halcyongoddess@gmail.com', N'reason')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (5, N'qdef', N'explan', N'rejected  ', N'A', CAST(0x0000995F00E4FA5C AS DateTime), N'reason', N'jenny', N'halcyongoddess@gmail.com', N'this was only a test')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (-9999, N'Unknown', N'The quality control level is unknown', N'rejected  ', N'E', CAST(0x0000996000A5B964 AS DateTime), N'THIS IS ONLY A TEST', N'jenny', N'halcyongoddess@gmail.com', N'IGNORE ME')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (-9999, N'Unknown', N'The quality control level is unknown', N'rejected  ', N'O', CAST(0x0000996000A5B964 AS DateTime), N'THIS IS ONLY A TEST', N'jenny', N'halcyongoddess@gmail.com', N'IGNORE ME')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (1, N'Quality controlled data', N'Quality controlled data that have passed quality assurance procedures such as routine estimation of timing and sensor calibration or visual inspection and removal of obvious errors. An example is USGS published streamflow records following parsing through USGS quality control procedures.', N'approved  ', N'E', CAST(0x0000996201720E60 AS DateTime), N'Make definition consistent with published text', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (1, N'Quality controlled data', N'Quality controlled data have passed quality assurance procedures such as routine estimation of timing and sensor calibration or visual inspection and removal of obvious errors. An example is USGS published streamflow records following parsing through USGS quality control procedures.', N'approved  ', N'O', CAST(0x0000996201720E60 AS DateTime), N'Make definition consistent with published text', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (2, N'Derived products', N'Derived products that require scientific and technical interpretation and may include multiple-sensor data. An example might be basin average precipitation derived from rain gages using an interpolation procedure.', N'approved  ', N'E', CAST(0x00009962017246A0 AS DateTime), N'consistency', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (2, N'Derived products', N'Derived products require scientific and technical interpretation and include multiple-sensor data. An example might be basin average precipitation derived from rain gages using an interpolation procedure.', N'approved  ', N'O', CAST(0x00009962017246A0 AS DateTime), N'consistency', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (4, N'Knowledge products', N'Knowledge products that require researcher driven scientific interpretation and multidisciplinary data integration and include model-based interpretation using other data and/or strong prior assumptions. An example is percentages of old or new water in a hydrograph inferred from an isotope analysis.', N'approved  ', N'E', CAST(0x0000996201728E1C AS DateTime), N'consistency', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (4, N'Knowledge products', N'These products require researcher (PI) driven scientific interpretation and multidisciplinary data integration and include model-based interpretation using other data and/or strong prior assumptions. An example is percentages of old or new water in a hydrograph inferred from an isotope analysis.', N'approved  ', N'O', CAST(0x0000996201728E1C AS DateTime), N'consistency', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (3, N'Interpreted products', N'Interpreted products that require researcher driven analysis and interpretation, model-based interpretation using other data and/or strong prior assumptions. An example is basin average precipitation derived from the combination of rain gages and radar return data.', N'approved  ', N'E', CAST(0x000099620172D91C AS DateTime), N'consistency', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (3, N'Interpreted products', N'These products require researcher (PI) driven analysis and interpretation, model-based interpretation using other data and/or strong prior assumptions. An example is basin average precipitation derived from the combination of rain gages and radar return data.', N'approved  ', N'O', CAST(0x000099620172D91C AS DateTime), N'consistency', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (0, N'Raw data', N'Raw and unprocessed data and data products that have not undergone quality control.  Depending on the variable, data type, and data transmission system, raw data may be available within seconds or minutes after the measurements have been made.', N'approved  ', N'E', CAST(0x00009962017190FC AS DateTime), N'Improve text and reconcile with paper', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (0, N'Raw data', N'Raw data is defined as unprocessed data and data products that have not undergone quality control. Depending on the data type and data transmission system, raw data may be available within seconds or minutes after real-time. Examples include real time precipitation, streamflow and water quality measurements.', N'approved  ', N'O', CAST(0x00009962017190FC AS DateTime), N'Improve text and reconcile with paper', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
/****** Object:  Table [dbo].[temp_GeneralCategoryCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_GeneralCategoryCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_GeneralCategoryCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The general category is not known', N'rejected  ', N'E', CAST(0x0000994300B853E4 AS DateTime), N'''This is a test', N'David Tarboton', N'david.tarboton@usu.edu', N'Reject this because it was a test')
INSERT [dbo].[temp_GeneralCategoryCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The general category is unknown', N'rejected  ', N'O', CAST(0x0000994300B853E4 AS DateTime), N'''This is a test', N'David Tarboton', N'david.tarboton@usu.edu', N'Reject this because it was a test')
INSERT [dbo].[temp_GeneralCategoryCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Instrumentation', N'For information regarding the operational characteristics of instrumentation used to collect data from hydrological observations.  This data may not be directly related to science, but may be useful for field technicians to report on, battery voltages datalogger errors, or high datalogger temperatures etc.', N'approved  ', N'A', CAST(0x000099B20176B17C AS DateTime), N'as per definition', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'Accepted with shortening.')
INSERT [dbo].[temp_GeneralCategoryCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Geology2', N'Data associated with geology or geological processes', N'rejected  ', N'E', CAST(0x00009AEE0061AD78 AS DateTime), N'', N'', N'', N'does not make sense')
INSERT [dbo].[temp_GeneralCategoryCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Geology', N'Data associated with geology or geological processes', N'rejected  ', N'O', CAST(0x00009AEE0061AD78 AS DateTime), N'', N'', N'', N'does not make sense')
/****** Object:  Table [dbo].[temp_DataTypeCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_DataTypeCV](
	[Term] [nvarchar](100) NOT NULL,
	[Definition] [nvarchar](500) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The data type is unknown', N'rejected  ', N'E', CAST(0x0000994300A60C98 AS DateTime), N'blah', N'jen', N'halcyongoddess@gmail.com', N'asdf')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Not known', N'The data type is unknown', N'rejected  ', N'O', CAST(0x0000994300A60C98 AS DateTime), N'blah', N'jen', N'halcyongoddess@gmail.com', N'asdf')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Instantaneous', N'A quantity specified in an instant with sufficient frequency (small spacing) to be interpreted as an instantaneous record of the phenomenon.', N'rejected  ', N'A', CAST(0x0000995300AE5358 AS DateTime), N'Term not on list and is useful to our data.', N'Jean Miller', N'jmiller@iagt.org', N'Jean - We are saying no to this, because we interpret what you have written as consistent with what we are calling continuous.')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Median', N'The values represent the median over a time interval, such as daily median discharge or daily median temperature.', N'approved  ', N'A', CAST(0x0000995A0098C2A4 AS DateTime), N'I have a turbidity sensor that returns the median value of 100 instantaneous observations.', N'Jeff Horsburgh', N'jeff.horsburgh@usu.edu', N'Done')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'StandardDeviation', N'The values represent the standard deviation of a set of observations made over a time interval. Standard deviation computed using the unbiased formula SQRT(SUM((Xi-mean)^2)/(n-1)) are preferred. The specific formula used to compute variance can be noted in the methods description.', N'approved  ', N'A', CAST(0x0000995F010235F4 AS DateTime), N'This is a useful measure of variability', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'term', N'def', N'rejected  ', N'A', CAST(0x0000995F0104DC78 AS DateTime), N'THIS IS A TEST', N'jenny', N'halcyongoddess@gmail.com', N'THIS IS A TEST')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'TEST', N'TEST DEFINITION', N'rejected  ', N'A', CAST(0x0000996000B1A9A4 AS DateTime), N'IGNORE THIS REQUEST: TESTING IF EMAILS ARE GETTING SENT', N'jenny', N'jennyb@cc.usu.edu', N'IGNORE ME')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Mode', N'The values are the most frequent values occurring at some time during a time interval, such as annual most frequent wind direction.', N'approved  ', N'A', CAST(0x00009A3F01451E14 AS DateTime), N'Need a mode datatype', N'Jamie Vleeshouwer', N'jamie.vleeshouwer@csiro.au', N'OK')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Median', N'The values represent the median over a time interval, such as daily median discharge or daily median temperature.', N'rejected  ', N'A', CAST(0x0000993E009731DC AS DateTime), N'Not yet contained within the controlled vocabulary.', N'Jeff Horsburgh', N'jeff.horsburgh@usu.edu', N'no. just no.')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Median', N'The values represent the median over a time interval, such as daily median discharge or daily median temperature.', N'rejected  ', N'D', CAST(0x0000993E00985350 AS DateTime), N'I am just testing for now', N'Jeff Horsburgh', N'jeff.horsburgh@usu.edu', N'testing admin notes')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The data type is unknown and will never be known', N'approved  ', N'E', CAST(0x0000993E00B4A6E0 AS DateTime), N'To test the change capability', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The data type is unknown', N'approved  ', N'O', CAST(0x0000993E00B4A6E0 AS DateTime), N'To test the change capability', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Not known', N'The data type is unknown and will never be known', N'approved  ', N'E', CAST(0x0000993E00BEBC84 AS DateTime), N'a test', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The data type is unknown and will never be known', N'approved  ', N'O', CAST(0x0000993E00BEBC84 AS DateTime), N'a test', N'David Tarboton', N'david.tarboton@usu.edu', NULL)
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Not known', N'The data type is unknown and will never be known', N'approved  ', N'E', CAST(0x0000993E00BFFB44 AS DateTime), N'a test again', N'David Tarboton', N'david.tarboton@usu.edu', N'testing this functionality')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The data type is unknown and will never be known', N'approved  ', N'O', CAST(0x0000993E00BFFB44 AS DateTime), N'a test again', N'David Tarboton', N'david.tarboton@usu.edu', N'testing this functionality')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Unknown', N'The data type is unknown', N'approved  ', N'E', CAST(0x0000993F00F3DC20 AS DateTime), N'To fix a change we made yesterday', N'David Tarboton', N'david.tarboton@usu.edu', N'Done')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Not known', N'The data type is unknown', N'approved  ', N'O', CAST(0x0000993F00F3DC20 AS DateTime), N'To fix a change we made yesterday', N'David Tarboton', N'david.tarboton@usu.edu', N'Done')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'DELETE ME', N'DISREGARD THIS CHANGE', N'rejected  ', N'A', CAST(0x0000995F00CFC768 AS DateTime), N'THIS IS TO TEST IF SUBMITTER INFO IS BEING INCLUDED IN OUTGOING EMAILS', N'Jenny Blumberg', N'halcyongoddess@gmail.com', N'Rejected')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Variance', N'The values represent the variance of a set of observations made over a time interval.', N'approved  ', N'A', CAST(0x0000995A00998D60 AS DateTime), N'I have a turbidity sensor that returns the variance of 100 instantaneous observations made over a 5 second time period.', N'Jeff Horsburgh', N'jeff.horsburgh@usu.edu', N'Done with additions to definition.')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Best Easy Systematic Estimator', N'Given 100 observations, the Best Easy Systematic Estimator is estimated as the sum of the 25th, 50th, 51st, and 76th observation divided by four.', N'approved  ', N'A', CAST(0x0000995A009B0A3C AS DateTime), N'I have a turbidity sensor that returns this statistic for a set of 100 instantaneous observations made over a 5 second time period.', N'Jeff Horsburgh', N'jeff.horsburgh@usu.edu', N'Accepted with modified definition')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'new term', N'', N'approved  ', N'A', CAST(0x0000994300A39044 AS DateTime), N'because', N'jenny', N'halcyongoddess@gmail.com', N'asdf')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Sporadic', N'The phenomenon is sampled at a particular instant in time', N'approved  ', N'E', CAST(0x0000994300A9527C AS DateTime), N'blah', N'jenny', N'halcyongoddess@gmail.com', N'ffdsasdf')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Sporadic', N'The phenomenon is sampled at a particular instant in time but with a frequency that is too coarse for interpreting the record as continuous.  This would be the case when the spacing is significantly larger than the support and the time scale of fluctuation of the phenomenon, such as for example infrequent water quality samples.', N'approved  ', N'O', CAST(0x0000994300A9527C AS DateTime), N'blah', N'jenny', N'halcyongoddess@gmail.com', N'ffdsasdf')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Variance', N'The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description.', N'approved  ', N'E', CAST(0x0000995F010E9EE8 AS DateTime), N'Fixing punctuation', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
INSERT [dbo].[temp_DataTypeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Variance', N'The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description', N'approved  ', N'O', CAST(0x0000995F010E9EE8 AS DateTime), N'Fixing punctuation', N'David Tarboton', N'david.tarboton@usu.edu', N'OK')
/****** Object:  Table [dbo].[temp_CVTESTER]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_CVTESTER](
	[sqlUpdateStatement] [varchar](2000) NULL,
	[time_stamp] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO DataTypeCV VALUES (''new term'','''')', CAST(0x0000994300AA7D50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''asdf'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007  9:55AM''', CAST(0x0000994300AA7D50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SpatialReferences SET status = ''rejected'', admin_notes = ''asdf'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 10:08AM''', CAST(0x0000994300AAC148 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''asdf'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 10:04AM''', CAST(0x0000994300AADD68 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE DataTypeCV SET Term = ''Sporadic'',Definition = ''The phenomenon is sampled at a particular instant in time'' WHERE Term = ''Sporadic''', CAST(0x0000994300AAEA4C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''ffdsasdf'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 10:16AM''', CAST(0x0000994300AAEA4C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE SpatialReferences SET SpatialReferenceID = 9,SRSID = ''26708'',SRSName = ''NAD27 / UTM zone 8N'',IsGeographic = ''True'',Notes = '''' WHERE SpatialReferenceID = 9', CAST(0x0000994300AB147C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SpatialReferences SET status = ''approved'', admin_notes = ''bhlbjlbjkbkl'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 10:19AM''', CAST(0x0000994300AB147C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE DataTypeCV SET Term = ''Unknown'',Definition = ''The data type is unknown'' WHERE Term = ''Not known''', CAST(0x0000994300AD9904 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''Done'' WHERE CONVERT(VARCHAR,time_stamp) = ''May 31 2007  2:47PM''', CAST(0x0000994300AD9904 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''fake units'',''length'',''fu'')', CAST(0x0000994300B11BD8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''I am temporarily accepting this to see if the system works.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 10:42AM''', CAST(0x0000994300B11BD8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 302,UnitsName = ''fake units of area'',UnitsType = ''area'',UnitsAbbreviation = ''fu'' WHERE UnitsID = 302', CAST(0x0000994300B2D928 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''Still testing.  I am accepting this change - but modifying it a but '' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 10:49AM''', CAST(0x0000994300B2D928 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM Units WHERE UnitsID = 302', CAST(0x0000994300B3F394 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''Yes we want to delete this to get things cleaned up.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 10:53AM''', CAST(0x0000994300B3F394 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''I am rejecting this change because it is not a good idea.  This was a test to see what happens when we reject a change.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 10:56AM''', CAST(0x0000994300B49EAC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''I am rejecting this test.  I am also putting some special characters in this note to see if the system can handle them '' *&^!@#$+-'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:02AM''', CAST(0x0000994300B720DC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''I am rejecting this test. I am also putting some special characters in here to see if they work !@#$%^&*+-'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:02AM''', CAST(0x0000994300B785A4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''This was a test'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:09AM''', CAST(0x0000994300B823D8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_GeneralCategoryCV SET status = ''rejected'', admin_notes = ''I am rejecting this test ''**$'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:11AM''', CAST(0x0000994300B8AE20 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_GeneralCategoryCV SET status = ''rejected'', admin_notes = ''I am rejecting this test '' *'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:11AM''', CAST(0x0000994300B8CB6C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_GeneralCategoryCV SET status = ''rejected'', admin_notes = ''Reject this because it was a test'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:11AM''', CAST(0x0000994300B941C8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE VariableNameCV SET Term = ''Nitrogen, nitrate (NO3) nitrogen as NO3 changed'',Definition = '''' WHERE Term = ''Nitrogen, nitrate (NO3) nitrogen as NO3''', CAST(0x0000994401177A7C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''Yes accept this'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  5 2007  4:54PM''', CAST(0x0000994401177A7C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE VariableNameCV SET Term = ''Nitrogen, nitrate (NO3) nitrogen as NO3'',Definition = '''' WHERE Term = ''Nitrogen, nitrate (NO3) nitrogen as NO3 changed''', CAST(0x0000994401180F50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''Accept'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  5 2007  4:58PM''', CAST(0x0000994401180F50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VerticalDatumCV SET status = ''rejected'', admin_notes = ''Do not accept this test'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  5 2007  7:04PM''', CAST(0x00009944013AC220 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Use International Foot, unit ID 48'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 13 2007 10:47AM''', CAST(0x0000994E0122067C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VerticalDatumCV SET status = ''rejected'', admin_notes = ''perhaps a couple of things to clarify
 
1) your NAD83/UTM Zone 18 N is a HORIZONTAL datum, not a vertical
 
2) there is no NAVD83, there is only a NAVD29 and NAVD88 and those are the only two VERTICAL datum we deal with.
 
Hope this helps'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 20 2007 10:23AM''', CAST(0x0000995400EAC144 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VerticalDatumCV SET status = ''rejected'', admin_notes = ''junk'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 21 2007  2:18PM''', CAST(0x0000995400EC3010 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO SampleTypeCV VALUES (''No Sample'',''There is no lab sample associated with this measurement'')', CAST(0x0000995400EE9044 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SampleTypeCV SET status = ''approved'', admin_notes = ''This is a good idea.  I tweaked the wording a bit.  This can also be accommodated by leaving the SampleID NULL.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 20 2007 10:25AM''', CAST(0x0000995400EE9044 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''Jean - We are saying no to this, because we interpret what you have written as consistent with what we are calling continuous.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 20 2007 10:34AM''', CAST(0x0000995400EF9B74 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''More specificity as to what is being measured, or what the depth is, needed.  Look at the Offset concept in ODM.  I think this captures what you want to do.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 20 2007 10:27AM''', CAST(0x0000995400EFF808 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO DataTypeCV VALUES (''Median'',''The values represent the median over a time interval, such as daily median discharge or daily median temperature.'')', CAST(0x0000995A00AC5C9C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''Done'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 27 2007  9:16AM''', CAST(0x0000995A00AC5C9C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO DataTypeCV VALUES (''Variance'',''The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description'')', CAST(0x0000995A00AD7BB8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''Done with additions to definition.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 27 2007  9:19AM''', CAST(0x0000995A00AD7BB8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''ok'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 27 2007 10:21PM''', CAST(0x0000995B004FDDB4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM VariableNameCV WHERE Term = ''Temperature, air''', CAST(0x0000995B004FEA98 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''ok'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 27 2007 10:24PM''', CAST(0x0000995B004FEA98 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM VariableNameCV WHERE Term = ''Temperature, water''', CAST(0x0000995B004FFC2C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''ok'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 27 2007 10:25PM''', CAST(0x0000995B004FFC2C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO DataTypeCV VALUES (''Best Easy Systematic Estimator'',''The Best Easy Systematic Estimator is defined as BES = (Q1 +2Q2 +Q3)/4 where Q1, Q2, and Q3 are the first, second, and third quartiles, respectively. BES is robust with respect to extreme values but represents the bulk of the common results.  See  Woodcock, F. and Engel, C., 2005: Operational Consensus Forecasts.Weather and Forecasting, 20, 101-111. (http://www.bom.gov.au/nmoc/bulletins/60/article_by_Woodcock_in_Weather_and_Forecasting.pdf) and Wonnacott, T. H., and R. J. Wonnacott, 1972: Introductory Statistics. Wiley, 510 pp.'')', CAST(0x0000995A00AF2AF8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM VariableNameCV WHERE Term = ''Discharge, daily average''', CAST(0x0000995B004FDDB4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Battery voltage'',''The battery voltage of a datalogger or sensing system, often recorded as an indicator of data reliability'')', CAST(0x0000995B005014C8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''ok'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 27 2007 10:27PM''', CAST(0x0000995B005014C8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO SampleMediumCV VALUES (''Other'',''Sample medium not relevant in the context of the measurement'')', CAST(0x0000995B010BA404 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SampleMediumCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:06AM''', CAST(0x0000995B010BA404 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO SampleMediumCV VALUES (''Snow'',''Observation in, of or sample taken from snow'')', CAST(0x0000995B010CED50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SampleMediumCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:07AM''', CAST(0x0000995B010CED50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO DataTypeCV VALUES (''Best Easy Systematic Estimator'',''The Best Easy Systematic Estimator is defined as BES = (Q1 +2Q2 +Q3)/4 where Q1, Q2, and Q3 are the first, second, and third quartiles, respectively. BES is robust with respect to extreme values but represents the bulk of the common results.  See  Woodcock, F. and Engel, C., 2005: Operational Consensus Forecasts.Weather and Forecasting, 20, 101-111. (http://www.bom.gov.au/nmoc/bulletins/60/article_by_Woodcock_in_Weather_and_Forecasting.pdf) and Wonnacott, T. H., and R. J. Wonnacott, 1972: Introductory Statistics. Wiley, 510 pp.'')', CAST(0x0000995B010E6DB0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Bulk electrical conductivity'',''Bulk electrical conductivity of a medium measured using a sensor such as time domain reflectometry (TDR), as a raw sensor response in the measurement of a quantity like soil moisture.'')', CAST(0x0000995B010F5108 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:46AM''', CAST(0x0000995B010F5108 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Carbon dioxide as voltage'',''The voltage sensor response from a carbon dioxide sensor'')', CAST(0x0000995B01107024 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:47AM''', CAST(0x0000995B01107024 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Oxygen as voltage'',''The voltage sensor response from an Oxygen sensor'')', CAST(0x0000995B0110B41C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:50AM''', CAST(0x0000995B0110B41C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''TDR waveform relative length'',''Time domain reflextometry, apparent length divided by probe length. Square root of dielectric.'')', CAST(0x0000995B0110E680 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:52AM''', CAST(0x0000995B0110E680 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Volumetric water content'',''Volume of liquid water relative to bulk volume.  Used for example to quantify soil moisture.'')', CAST(0x0000995B01117320 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:54AM''', CAST(0x0000995B01117320 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Temperature as resistance'',''The electrical resistance sensor response from a temperature sensor such as a thermistor'')', CAST(0x0000995B01122414 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007  3:01PM''', CAST(0x0000995B01122414 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''No - this is already there as item 168'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:15AM''', CAST(0x0000995B01126A64 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''No - this is already there as item 176'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:19AM''', CAST(0x0000995B0112A2A4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''No - this is already there as item 169'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:20AM''', CAST(0x0000995B0112E1EC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''decisiemens per centimeter'',''Electrical Conductivity'',''dS/cm'')', CAST(0x0000995B0113C8C8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''decisiemens per centimeter'',''Electrical Conductivity'',''dS/cm'')', CAST(0x0000995B011427B4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''decisiemens per centimeter'',''Electrical Conductivity'',''dS/cm'')', CAST(0x0000995B0115C1DC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''decisiemens per centimeter'',''Electrical Conductivity'',''dS/cm'')', CAST(0x0000995B0117C57C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''decisiemens per centimeter'',''Electrical Conductivity'',''dS/cm'')', CAST(0x0000995B0119ED70 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Reject for Typo - I submitted one with correct spelling'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007 11:21AM''', CAST(0x0000995B011E3FB0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 269,UnitsName = ''millisiemens per centimeter'',UnitsType = ''Electrical Conductivity'',UnitsAbbreviation = ''mS/cm'' WHERE UnitsID = 269', CAST(0x0000995B011EB60C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007  5:20PM''', CAST(0x0000995B011EB60C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''muddled up'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007  5:33PM''', CAST(0x0000995B01226310 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 192,UnitsName = ''microsiemens per centimeter'',UnitsType = ''Electrical Conductivity'',UnitsAbbreviation = ''uS/cm'' WHERE UnitsID = 192', CAST(0x0000995B012291F0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007  5:34PM''', CAST(0x0000995B0122931C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 268,UnitsName = ''siemens per meter'',UnitsType = ''Electrical Conductivity'',UnitsAbbreviation = ''S/m'' WHERE UnitsID = 268', CAST(0x0000995B012342E4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007  5:38PM''', CAST(0x0000995B012342E4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 270,UnitsName = ''siemens per centimeter'',UnitsType = ''Electrical Conductivity'',UnitsAbbreviation = ''S/cm'' WHERE UnitsID = 270', CAST(0x0000995B012357FC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007  5:39PM''', CAST(0x0000995B012357FC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''a test new unit'',''length'',''atnu'')', CAST(0x0000995B0123F75C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''because it is a test'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007  5:42PM''', CAST(0x0000995B01248654 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''decisiemens per centimeter'',''Electrical Conductivity'',''dS/cm'')', CAST(0x0000995D006C8B80 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''decisiemens per centimeter'',''Electrical Conductivity'',''dS/cm'')', CAST(0x0000995D006CB22C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (303,''ducks feet'',''length'',''df'')', CAST(0x0000995F00E65C44 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''accept temporarily - to delete later'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  1:56PM''', CAST(0x0000995F00E65C44 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM Units WHERE UnitsID = 303', CAST(0x0000995F00E6D87C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  1:59PM''', CAST(0x0000995F00E6D87C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE QualityControlLevels SET QualityControlLevelID = ''2'',Definition = '''',Explanation = ''explanation'' WHERE QualityControlLevelID = 2', CAST(0x000099430107C94C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''approved'', admin_notes = ''reason'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007  1:45PM''', CAST(0x000099430107C94C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''no. just no.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007  3:30PM''', CAST(0x00009943010D8224 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''no. just no.'' WHERE CONVERT(VARCHAR,time_stamp) = ''May 30 2007  9:10AM''', CAST(0x00009943010DF2A4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO DataTypeCV VALUES (''Best Easy Systematic Estimator'',''Best Easy Systematic Estimator BES = (Q1 +2Q2 +Q3)/4.  Q1, Q2, and Q3 are first, second, and third quartiles. See Woodcock, F. and Engel, C., 2005: Operational Consensus Forecasts.Weather and Forecasting, 20, 101-111. (http://www.bom.gov.au/nmoc/bulletins/60/article_by_Woodcock_in_Weather_and_Forecasting.pdf) and Wonnacott, T. H., and R. J. Wonnacott, 1972: Introductory Statistics. Wiley, 510 pp.'')', CAST(0x0000995F00EA57CC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''Accepted with modified definition'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 27 2007  9:24AM''', CAST(0x0000995F00EA57CC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''THIS IS A TEST'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  3:49PM''', CAST(0x0000995F0104F3E8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''THIS IS A TEST'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  3:49PM''', CAST(0x0000995F01079F1C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''THIS IS A TEST'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  3:49PM''', CAST(0x0000995F0107CA78 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Reject'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  4:22PM''', CAST(0x0000995F010E0438 AS DateTime))
GO
print 'Processed 100 total records'
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE DataTypeCV SET Term = ''Variance'',Definition = ''The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description.'' WHERE Term = ''Variance''', CAST(0x0000995F010EC468 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  4:25PM''', CAST(0x0000995F010EC468 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''no'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  4:33PM''', CAST(0x0000995F011117B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''dust'',''stuff that is everywhere'')', CAST(0x0000995F0111A0D4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''ok'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  4:35PM''', CAST(0x0000995F0111A0D4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''ok'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  4:37PM''', CAST(0x0000995F01124610 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM VariableNameCV WHERE Term = ''dust''', CAST(0x0000995F011612B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  4:51PM''', CAST(0x0000995F011612B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE VariableNameCV SET Term = ''Sulfur, Organic'',Definition = ''Organic Sulfur'' WHERE Term = ''Sulfur, rganic''', CAST(0x0000995F0116DB1C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''ok'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  4:54PM''', CAST(0x0000995F0116DB1C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''no'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007 11:41AM''', CAST(0x0000996000C0DB18 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''because'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007  3:41PM''', CAST(0x0000996200D43820 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE QualityControlLevels SET QualityControlLevelID = 1,Definition = ''Quality controlled data'',Explanation = ''Quality controlled data that have passed quality assurance procedures such as routine estimation of timing and sensor calibration or visual inspection and removal of obvious errors. An example is USGS published streamflow records following parsing through USGS quality control procedures.'' WHERE QualityControlLevelID = 1', CAST(0x0000996201733358 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  5 2007 10:27PM''', CAST(0x0000996201733358 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE QualityControlLevels SET QualityControlLevelID = 0,Definition = ''Raw data'',Explanation = ''Raw and unprocessed data and data products that have not undergone quality control.  Depending on the variable, data type, and data transmission system, raw data may be available within seconds or minutes after the measurements have been made. Examples include real time precipitation, streamflow and water quality measurements.'' WHERE QualityControlLevelID = 0', CAST(0x0000996201737048 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  5 2007 10:25PM''', CAST(0x0000996201737048 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE QualityControlLevels SET QualityControlLevelID = 2,Definition = ''Derived products'',Explanation = ''Derived products that require scientific and technical interpretation and may include multiple-sensor data. An example is basin average precipitation derived from rain gages using an interpolation procedure.'' WHERE QualityControlLevelID = 2', CAST(0x000099620173C250 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  5 2007 10:28PM''', CAST(0x000099620173C250 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE QualityControlLevels SET QualityControlLevelID = 3,Definition = ''Interpreted products'',Explanation = ''Interpreted products that require researcher driven analysis and interpretation, model-based interpretation using other data and/or strong prior assumptions. An example is basin average precipitation derived from the combination of rain gages and radar return data.'' WHERE QualityControlLevelID = 3', CAST(0x000099620173DF9C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  5 2007 10:30PM''', CAST(0x000099620173DF9C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE QualityControlLevels SET QualityControlLevelID = 4,Definition = ''Knowledge products'',Explanation = ''Knowledge products that require researcher driven scientific interpretation and multidisciplinary data integration and include model-based interpretation using other data and/or strong prior assumptions. An example is percentages of old or new water in a hydrograph inferred from an isotope analysis.'' WHERE QualityControlLevelID = 4', CAST(0x00009962017402C4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  5 2007 10:29PM''', CAST(0x00009962017402C4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''Mike, if you receive this, please let me know. If it works this is the last test that we''''ll need to do. Thank you for your patience!'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007  3:41PM''', CAST(0x0000996300EFB2E4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Snow Water Equivalent'',''The depth of water if a snow cover is completely melted, expressed in units of depth, on a corresponding horizontal surface area.'')', CAST(0x00009985015767B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''Done'' WHERE CONVERT(VARCHAR,time_stamp) = ''Aug  9 2007  8:47PM''', CAST(0x00009985015767B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (304,''Joules per square centimeter'',''Solar Radiation'',''J/cm2'')', CAST(0x0000999200AE2A54 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Aug 22 2007 10:32AM''', CAST(0x0000999200AE2A54 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM VariableNameCV WHERE Term = ''Radiation, total PAR''', CAST(0x00009992015D0EFC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Aug 22 2007  9:06PM''', CAST(0x00009992015D0EFC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_GeneralCategoryCV SET status = ''rejected'', admin_notes = '''''' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:11AM''', CAST(0x0000994300B918C4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (303,''micromoles per liter'',''Concentration'',''umol/L'')', CAST(0x000099870109DFAC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''Done (note I changed the L to upper case for consistency)'' WHERE CONVERT(VARCHAR,time_stamp) = ''Aug 10 2007  8:16AM''', CAST(0x000099870109DFAC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE VariableNameCV SET Term = ''Radiation, net PAR'',Definition = ''Net Photosynthetically-Active Radiation'' WHERE Term = ''Radiation, net photosynthetically-active''', CAST(0x00009992015D266C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Aug 22 2007  9:07PM''', CAST(0x00009992015D266C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeter per hour'',''precipitation'',''mm/hr'')', CAST(0x000099A700BD9660 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeter per hour'',''precipitation'',''mm/hr'')', CAST(0x000099A700BDE160 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (306,''parts per thousand'',''Concentration'',''ppth'')', CAST(0x000099AE017AB2E0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK - abbreviation changed to ppth to avoid clash with parts per trillion that is already there with ppt'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 19 2007 12:20PM''', CAST(0x000099AE017AB2E0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (307,''megaliter'',''Volume'',''ML'')', CAST(0x000099B20165CD44 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 23 2007  9:23PM''', CAST(0x000099B20165CD44 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''Please see other Nitrogen variables such as "Nitrogen, nitrite (NO2) + nitrate (NO3) nitrogen as N".  Is this what you are intending.  I am concerned that "Nitrate/Nitrite" is not specific enough, but adding to the definition with units does not really clarify.  Can you help in working through all these chemical variable definitions to get them right?  Is there a reference or source for these that we should be using, rather than addressing one at a time?'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:31PM''', CAST(0x000099B30146223C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Nitrogen, Dissolved Inorganic'',''Dissolved inorganic nitrogen'')', CAST(0x000099B301469E74 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:32PM''', CAST(0x000099B301469E74 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Nitrogen, Dissolved Organic'',''Dissolved Organic Nitrogen'')', CAST(0x000099B30146C8A4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:33PM''', CAST(0x000099B30146C8A4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Primary Productivity'',''Primary Productivity'')', CAST(0x000099B301471854 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:34PM''', CAST(0x000099B301471854 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Chlorophyll c1 and c2'',''Chlorophyll c1 and c2'')', CAST(0x000099B301477614 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''Can you please expand the definition (I am accepting so do this as an edit)'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:35PM''', CAST(0x000099B301477614 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Carbon to Nitrogen molar ratio'',''Carbon to Nitrogen molar ratio'')', CAST(0x000099B30147A044 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Good to see you exercising this - but it is not specific enough to include.  (Dave from Scripps)'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 26 2007 11:24AM''', CAST(0x000099B500BE4E5C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''This is already there'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:36PM''', CAST(0x000099B60000E358 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''Use "Nitrogen, nitrite (NO2) + nitrate (NO3) nitrogen as N"'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:37PM''', CAST(0x000099B600021660 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Peridinin'',''The phytoplankton pigment Peridinin'')', CAST(0x000099B600027EAC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:38PM''', CAST(0x000099B600027EAC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''19''''-Hexanoyloxyfucoxanthin'',''The phytoplankton pigment 19''''-Hexanoyloxyfucoxanthin'')', CAST(0x000099B60002ECD4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''19-Hexanoyloxyfucoxanthin'',''The phytoplankton pigment 19-Hexanoyloxyfucoxanthin'')', CAST(0x000099B600031704 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:39PM''', CAST(0x000099B600031704 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''9 cis-Neoxanthin'',''The phytoplankton pigment  9 cis-Neoxanthin'')', CAST(0x000099B60003F354 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:40PM''', CAST(0x000099B60003F354 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Diadinoxanthin'',''The phytoplankton pigment Diadinoxanthin'')', CAST(0x000099B60004AB50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:41PM''', CAST(0x000099B60004AB50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Alloxanthin'',''The phytoplankton pigment Alloxanthin'')', CAST(0x000099B6000506B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:42PM''', CAST(0x000099B6000506B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Zeaxanthin'',''The phytoplankton pigment Zeaxanthin'')', CAST(0x000099B600054024 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:43PM''', CAST(0x000099B600054024 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Diatoxanthin'',''The phytoplankton pigment Diatoxanthin'')', CAST(0x000099B6000587A0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:44PM''', CAST(0x000099B6000587A0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Canthaxanthin'',''The phytoplankton pigment Canthaxanthin'')', CAST(0x000099B60005BFE0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:45PM''', CAST(0x000099B60005BFE0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Cryptophytes'',''The chlorophyll a concentration contributed by cryptophytes'')', CAST(0x000099B6000633E4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:46PM''', CAST(0x000099B6000633E4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Dinoflagellates'',''The chlorophyll a concentration contributed by Dinoflagellates'')', CAST(0x000099B600067EE4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:47PM''', CAST(0x000099B600067EE4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Chlorophyll a allomer'',''The phytoplankton pigment Chlorophyll a allomer'')', CAST(0x000099B60006F9F0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:48PM''', CAST(0x000099B60006F9F0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Chlorophyll Fluorescence'',''Chlorophyll Fluorescence'')', CAST(0x000099B600076110 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:51PM''', CAST(0x000099B600076110 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (306,''Percent Saturation'',''Concentration'',''% Sat'')', CAST(0x000099B6000803F4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''I will be entering - but due to a glitch in our system need to reject.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 19 2007 12:21PM''', CAST(0x000099B600088BE4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (308,''Percent Saturation'',''Concentration'',''% Sat'')', CAST(0x000099B60009117C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_GeneralCategoryCV SET status = ''rejected'', admin_notes = ''This is''nt a good idea'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:11AM''', CAST(0x0000994300B9085C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''Michael please call me or email me if this message gets to you (435-797-8034)'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007  3:41PM''', CAST(0x0000996200A80930 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''ok'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  9 2007  6:47PM''', CAST(0x0000996700652494 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 27 2007 12:32AM''', CAST(0x000099B60009117C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Just use percent'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 19 2007 12:22PM''', CAST(0x000099B600095B50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''use dimensionless for these ratios'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 19 2007 12:24PM''', CAST(0x000099B60009C5F4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Just use milligrams per liter.  carbon is specified in variable name (Carbon, dissolved inorganic)'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 19 2007 12:25PM''', CAST(0x000099B6000A7364 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Just use micrograms per liter.  Other info specified by variable'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 19 2007 12:27PM''', CAST(0x000099B6000AE894 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''just use micrograms per liter'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 19 2007 12:28PM''', CAST(0x000099B6000AFED8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Just use milligrams per cubic meter per hour'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 19 2007 12:29PM''', CAST(0x000099B6000B48AC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Water level'',''Water level relative to datum. The datum may be local or global such as NGVD 1929 and should be specified in the method description for associated data values.'')', CAST(0x000099BC00D98D5C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK Done - see expanded definition I used.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  3 2007  9:00AM''', CAST(0x000099BC00D98D5C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Velocity'',''The velocity of the water flowing through a channel'')', CAST(0x000099C200A9E3CC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''We accept this as a general variable "velocity" that can be applied to channel and or pipe.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  5:27AM''', CAST(0x000099C200A9E3CC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''We have discharge in the list and also quite a nuber of units to go wiht it, among them m^3/d.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  5:41AM''', CAST(0x000099C200AA1888 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Recorder code'',''A code used to identifier a data recorder.'')', CAST(0x000099C201170B28 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  4:43PM''', CAST(0x000099C201170B28 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Program signature'',''A unique data recorder program identifier which is useful for knowing when the source code in the data recorder has been modified.'')', CAST(0x000099C20117342C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  4:45PM''', CAST(0x000099C20117342C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Watchdog error count'',''A counter which counts the number of total datalogger watchdog errors'')', CAST(0x000099C201174CC8 AS DateTime))
GO
print 'Processed 200 total records'
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  4:46PM''', CAST(0x000099C201174CC8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Table overrun error count'',''A counter which counts the number of datalogger table overrun errors'')', CAST(0x000099C201176B40 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  4:48PM''', CAST(0x000099C201176B40 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Flash memory error count'',''A counter which counts the number of  datalogger flash memory errors'')', CAST(0x000099C201178760 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  4:49PM''', CAST(0x000099C201178760 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Low battery count'',''A counter of the number of times the battery voltage dropped below a minimum threshold'')', CAST(0x000099C20117A254 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  4:51PM''', CAST(0x000099C20117A254 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Container number'',''The identifying number for a water sampler container.'')', CAST(0x000099C20117D008 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  4:52PM''', CAST(0x000099C20117D008 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Sequence number'',''A counter of events in a sequence'')', CAST(0x000099C2011820E4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  4:54PM''', CAST(0x000099C2011820E4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''Handled using the variable "recorder code" that has just been added.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  1 2007 12:43AM''', CAST(0x000099C20118A8D4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Latitude'',''Latitude as a variable measurement or observation (Spatial reference to be designated in methods).  This is distinct from the latitude of a site which is a site attribute.'')', CAST(0x000099C900BE7634 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct 16 2007  9:19AM''', CAST(0x000099C900BE7634 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''TestTerm'',''Test'')', CAST(0x000099C9011B992C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''Rejecting test term'' WHERE convert(varchar,time_stamp,109) = ''Oct 16 2007  5:11:12:000PM''', CAST(0x000099C9011C004C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM VariableNameCV WHERE Term = ''TestTerm''', CAST(0x000099C9011C5380 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''Ok to remove now I am done with test.'' WHERE convert(varchar,time_stamp,109) = ''Oct 16 2007  5:14:50:000PM''', CAST(0x000099C9011C5380 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Phosphorus, total as P, filtered'',''Total Phosphorus as P, filtered sample'')', CAST(0x000099EB015FF5F4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Nov 19 2007  4:51:06:000PM''', CAST(0x000099EB015FF5F4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (311,''liters per hour'',''Flow'',''L/hr'')', CAST(0x00009A2A0176D24C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Jan 21 2008  7:19:16:000PM''', CAST(0x00009A2A0176D24C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Streamflow'',''The volume of water flowing past a fixed point.  Equivalent to discharge'')', CAST(0x00009A2A01773264 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Dec  6 2007  7:09:27:000AM''', CAST(0x00009A2A01773264 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Cleaning out'' WHERE convert(varchar,time_stamp,109) = ''Jan 15 2008  2:03:49:000PM''', CAST(0x00009A2A017749D4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO DataTypeCV VALUES (''Mode'',''The values are the most frequent values occurring at some time during a time interval, such as annual most frequent wind direction.'')', CAST(0x00009A3F01494D2C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Feb 11 2008  7:43:43:000PM''', CAST(0x00009A3F01494D2C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Jus use the inches per day with Units Type velocity.  We are treating precipitation rate as the same as velocity.'' WHERE convert(varchar,time_stamp,109) = ''Feb 18 2008  5:38:04:000PM''', CAST(0x00009A46012AF278 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_GeneralCategoryCV SET status = ''rejected'', admin_notes = ''I am rejecting this test '''' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  4 2007 11:11AM''', CAST(0x0000994300B8E084 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_TopicCategoryCV SET status = ''rejected'', admin_notes = ''reject this'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun  5 2007  7:10PM''', CAST(0x00009944013C4604 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 153,UnitsName = ''millimoles of photons per square meter'',UnitsType = ''Light'',UnitsAbbreviation = ''mmol/m2'' WHERE UnitsID = 153', CAST(0x0000996000988938 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''Your request entered the system as an edit, but I could not see any difference between what was there previously and what you are requesting.  Accepting this does not actually change anything.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007  5:00AM''', CAST(0x0000996000988938 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''rejected'', admin_notes = ''IGNORE ME'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007 10:03AM''', CAST(0x0000996000AE2DD8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''IGNORE ME'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007 10:46AM''', CAST(0x0000996000B21A24 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''IGNORE ME'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007  3:41PM''', CAST(0x000099600102BA60 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''MIKE: please let me know if you get a message regarding this change'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007  3:41PM''', CAST(0x0000996200C44EB0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''MIKE: Let me know if you receive this message.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007  3:41PM''', CAST(0x0000996300C94884 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Oct 16 2007  5:10:44:000PM''', CAST(0x000099C9011B992C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''No. Use precipitation.  There are lots of quantities that can be expressed as cumulative over an interval or instantaneous.  In ODM this distinction is through datatype.  We do not want separate variables for each one. This concept applies to precipitation, evaporation, radiation etc.'' WHERE convert(varchar,time_stamp,109) = ''Dec  6 2007 12:27:29:000AM''', CAST(0x000099FC007513E0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 305,UnitsName = ''millimeters per day'',UnitsType = ''velocity'',UnitsAbbreviation = ''mm/day'' WHERE UnitsID = 305', CAST(0x00009A46012B0664 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Feb 18 2008  6:06:45:000PM''', CAST(0x00009A46012B0664 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Just use the in/hr velocity unit.  We are interpreting velocity and precipitation rate as the same.  The exception is storm precipitation which has unit type of precipitation.'' WHERE convert(varchar,time_stamp,109) = ''Feb 18 2008  5:36:54:000PM''', CAST(0x00009A46012B67A8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO SampleMediumCV VALUES (''Not Relevant'',''Sample medium not relevant in the context of the measurement'')', CAST(0x00009A6601067B50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SampleMediumCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Mar 21 2008  3:34:17:000PM''', CAST(0x00009A6601067B50 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO SpatialReferences VALUES (225,''3308'',''GDA94 / NSW Lambert'',''False'',''Datum Name: Geocentric Datum of Australia 1994 Area of Use: Australia - New South Wales (NSW). Datum Origin: ITRF92 at epoch 1994.0  Ellipsoid Name: GRS 1980 Data Source: EPSG'')', CAST(0x00009A7700388B00 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SpatialReferences SET status = ''approved'', admin_notes = ''Added.'' WHERE convert(varchar,time_stamp,109) = ''Apr  6 2008  8:51:41:000PM''', CAST(0x00009A7700388B00 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''It sounds like the existing term: Precipitation (definition: Precipitation such as rainfall. Should not be confused with settling.)
would meet your needs.'' WHERE convert(varchar,time_stamp,109) = ''Apr 11 2008 12:53:54:000PM''', CAST(0x00009A7B00E156B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Nitrogen, ammonia (NH3) + ammonium (NH4)'',''see EPA method 350.1'')', CAST(0x00009AA10103AF4C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''The term: "Nitrogen, NH3 + NH4 as N" is already in the VariableNameCV.'' WHERE convert(varchar,time_stamp,109) = ''May 19 2008  2:57:07:000PM''', CAST(0x00009AA10103AF4C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''I do not understand what change you are asking for.  Both Original and New entries are the same in your request.  Please send email to me explaining what you need. There is a separate unit (ID=144) that is MJ/m2.'' WHERE convert(varchar,time_stamp,109) = ''Jul  1 2008 12:39:05:000AM''', CAST(0x00009ACC0107D504 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''See comment on similar request.'' WHERE convert(varchar,time_stamp,109) = ''Jul  1 2008 12:37:57:000AM''', CAST(0x00009ACC0107EFF8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''no way'' WHERE convert(varchar,time_stamp,109) = ''Jul 11 2008  5:18:42:000PM''', CAST(0x00009AD601241E08 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''no'' WHERE convert(varchar,time_stamp,109) = ''Jul 11 2008  8:37:34:000PM''', CAST(0x00009AD601834374 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''There is no difference between what you have proposed and what is in the vocabulary.  Please email me if you want to clarify what your request is.'' WHERE convert(varchar,time_stamp,109) = ''Aug 13 2008  3:29:25:000AM''', CAST(0x00009AF700B87CE8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_GeneralCategoryCV SET status = ''rejected'', admin_notes = ''does not make sense'' WHERE convert(varchar,time_stamp,109) = ''Aug  4 2008  5:55:38:000AM''', CAST(0x00009AF800DCC8B4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO SampleMediumCV VALUES (''Pore water'',''The water in soil pores'')', CAST(0x00009B1800D98528 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SampleMediumCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Sep 15 2008  1:10:09:000PM''', CAST(0x00009B1800D98528 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM SampleMediumCV WHERE Term = ''Pore water''', CAST(0x00009B1800DB00D8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SampleMediumCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Sep 15 2008  1:15:58:000PM''', CAST(0x00009B1800DB00D8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''No'' WHERE convert(varchar,time_stamp,109) = ''Sep 15 2008  1:41:20:000PM''', CAST(0x00009B1800E983B0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''No'' WHERE convert(varchar,time_stamp,109) = ''Sep 15 2008  6:05:29:000PM''', CAST(0x00009B1900B07DA4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE CensorCodeCV SET Term = ''gtt'',Definition = ''greater than'' WHERE Term = ''gt''', CAST(0x00009B5F00F7C998 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''approved'', admin_notes = ''ok'' WHERE convert(varchar,time_stamp,109) = ''Nov 25 2008  2:59:51:000PM''', CAST(0x00009B5F00F7C998 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE CensorCodeCV SET Term = ''gt'',Definition = ''greater than'' WHERE Term = ''gtt''', CAST(0x00009B5F00F83B44 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''approved'', admin_notes = ''ok'' WHERE convert(varchar,time_stamp,109) = ''Nov 25 2008  3:02:39:000PM''', CAST(0x00009B5F00F83B44 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 96,UnitsName = ''degree celsius'',UnitsType = ''Temperature'',UnitsAbbreviation = ''degC'' WHERE UnitsID = 96', CAST(0x00009BB900A51EB4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''Yes of course'' WHERE convert(varchar,time_stamp,109) = ''Feb 23 2009  9:10:40:000AM''', CAST(0x00009BB900A51EB4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (302,''decisiemens per centimeter'',''Electrical Conductivity'',''dS/cm'')', CAST(0x0000995F00CAB2A0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''I''''m am testing that the issue David found with not being able to add items to the Units table is fixed.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jun 28 2007  5:05PM''', CAST(0x0000995F00CABD2C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''Rejected'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007 12:36PM''', CAST(0x0000995F00E4DAB8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''rejected'', admin_notes = ''this was only a test'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  1:53PM''', CAST(0x0000995F00E724A8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE SampleMediumCV SET Term = ''Surface Water'',Definition = ''Observation or sample of surface water such as a stream, river, lake, pond, reservoir, ocean, etc.'' WHERE Term = ''Surface Water''', CAST(0x0000995F00E8C830 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_SampleMediumCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  2:05PM''', CAST(0x0000995F00E8C830 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''Reject'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  3:35PM''', CAST(0x0000995F01011930 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO DataTypeCV VALUES (''StandardDeviation'',''The values represent the standard deviation of a set of observations made over a time interval. Standard deviation computed using the unbiased formula SQRT(SUM((Xi-mean)^2)/(n-1)) are preferred. The specific formula used to compute variance can be noted in the methods description.'')', CAST(0x0000995F0102A8CC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  3:40PM''', CAST(0x0000995F0102A9F8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_DataTypeCV SET status = ''rejected'', admin_notes = ''THIS IS A TEST'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  2 2007  3:49PM''', CAST(0x0000995F0106A454 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_QualityControlLevels SET status = ''rejected'', admin_notes = ''IGNORE THIS'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007 10:03AM''', CAST(0x0000996000A62660 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''no'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  4 2007  6:37AM''', CAST(0x00009961006D4BB0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''IGNORE ME'' WHERE CONVERT(VARCHAR,time_stamp) = ''Jul  3 2007  3:41PM''', CAST(0x0000996200A67E44 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO GeneralCategoryCV VALUES (''Instrumentation'',''Data associated with instrumentation and instrument properties such as battery voltages, data logger temperatures, often useful for diagnosis.'')', CAST(0x000099B301419C6C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_GeneralCategoryCV SET status = ''approved'', admin_notes = ''Accepted with shortening.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 23 2007 10:44PM''', CAST(0x000099B301419C6C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''We suggest you just use "battery voltage" for this and distinguish which battery in the method description associated with corresponding data values.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 23 2007 10:35PM''', CAST(0x000099B3014337C0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''We suggest you use just temperature for this and indicate which temperature as part of the method.  Feel free to email me if you have strong counter opinions.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 23 2007 10:37PM''', CAST(0x000099B301437A8C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''Please provide a definition for what this is so we can consider including it.  I do not know what it is.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:29PM''', CAST(0x000099B30143EFBC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Carbon to Nitrogen molar ratio'',''C:N (molar)'')', CAST(0x000099B301448B98 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 24 2007 12:30PM''', CAST(0x000099B301448B98 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (310,''millimeters per second'',''Velocity'',''mm/s'')', CAST(0x000099F200A4A600 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Nov 25 2007 10:30:17:000PM''', CAST(0x000099F200A4A600 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Evapotranspiration, potential'',''The amount of water that could be evaporated and transpired if there was sufficient water available.'')', CAST(0x000099FC00718428 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''Good idea'' WHERE convert(varchar,time_stamp,109) = ''Dec  5 2007 11:30:43:000PM''', CAST(0x000099FC00718428 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Leaf wetness'',''The effect of moisture settling on the surface of a leaf as a result of either condensation or rainfall.'')', CAST(0x000099FC0071BA10 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''Good idea'' WHERE convert(varchar,time_stamp,109) = ''Dec  6 2007 12:13:41:000AM''', CAST(0x000099FC0071BA10 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Vapor pressure'',''The pressure of a vapor in equilibrium with its non-vapor phases'')', CAST(0x000099FC00720894 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''Good idea'' WHERE convert(varchar,time_stamp,109) = ''Dec  5 2007 11:38:06:000PM''', CAST(0x000099FC00720894 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''rejected'', admin_notes = ''lux is a measurement of light (already in the CV with ID=60), microEinsteins per sq. meter per second (already in the CV with ID=150) is a measurement of the rate of light.  They are sometimes equated, but for a more complete discussion, see: http://home.comcast.net/~cerny/pub/einsteins.html.'' WHERE convert(varchar,time_stamp,109) = ''Oct 13 2008  6:54:47:000AM''', CAST(0x00009B3500C00120 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 144,UnitsName = ''megajoules per square meter'',UnitsType = ''Energy per Area'',UnitsAbbreviation = ''MJ/m2'' WHERE UnitsID = 144', CAST(0x00009994016C87EC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Aug 24 2007 10:04PM''', CAST(0x00009994016C87EC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE Units SET UnitsID = 304,UnitsName = ''Joules per square centimeter'',UnitsType = ''Energy per Area'',UnitsAbbreviation = ''J/cm2'' WHERE UnitsID = 304', CAST(0x00009994016C95FC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Aug 24 2007 10:05PM''', CAST(0x00009994016C95FC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''Use the VariableName "Battery voltage" for all battery voltages.  We want to avoid having too much place information in the name.  We do not want this list to grow to internal, external, on top, underneath, adjacent etc.  Rather we suggest you describe the position of the sensor - such as internal and external in the method.'' WHERE convert(varchar,time_stamp,109) = ''Apr 11 2008  2:07:26:000PM''', CAST(0x00009A8000A4A72C AS DateTime))
GO
print 'Processed 300 total records'
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''Use the VariableName "Battery voltage" for all battery voltages.  We want to avoid having too much place information in the name.  We do not want this list to grow to internal, external, on top, underneath, adjacent etc.  Rather we suggest you describe the position of the sensor - such as internal and external in the method.'' WHERE convert(varchar,time_stamp,109) = ''Apr 11 2008  2:06:16:000PM''', CAST(0x00009A8000A4B410 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''no'' WHERE convert(varchar,time_stamp,109) = ''Jul 11 2008  9:44:27:000PM''', CAST(0x00009AD601835058 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''No'' WHERE convert(varchar,time_stamp,109) = ''Sep 15 2008  4:59:16:000PM''', CAST(0x00009B18012A50C0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''inches/hour'',''precipitation'',''in/hr'')', CAST(0x000099A700B62740 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 12 2007 10:53AM''', CAST(0x000099A700B62740 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeter per hour'',''precipitation'',''mm/hr'')', CAST(0x000099A700B63C58 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeter per hour'',''precipitation'',''mm/hr'')', CAST(0x000099A700B690B8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeter per hour'',''precipitation'',''mm/hr'')', CAST(0x000099A700B6B638 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeters per hour'',''precipitation'',''mm/hr'')', CAST(0x000099A700E0D6FC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM Units WHERE UnitsID = 305', CAST(0x000099A700E1765C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 12 2007  1:40PM''', CAST(0x000099A700E1765C AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeters per hour'',''precipitation'',''mm/hr'')', CAST(0x000099A700E18A48 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 12 2007 10:54AM''', CAST(0x000099A700E18A48 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeters per day'',''precipitation'',''mm/day'')', CAST(0x000099A700E1C4E0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM Units WHERE UnitsID = 305', CAST(0x000099A700E223CC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 12 2007  1:42PM''', CAST(0x000099A700E223CC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (305,''millimeters per day'',''precipitation'',''mm/day'')', CAST(0x000099A700E231DC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 12 2007 10:55AM''', CAST(0x000099A700E231DC AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Signal-to-noise ratio'',''Signal-to-noise ratio (often abbreviated SNR or S/N) is defined as the ratio of a signal power to the noise power corrupting the signal. The higher the ratio, the less obtrusive the background noise is.'')', CAST(0x000099C10175BC90 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  8 2007  7:13PM''', CAST(0x000099C10175BC90 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Volume'',''Volume. To quantify discharge or hydrograph volume or some other volume measurement.'')', CAST(0x000099C20166B420 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  9 2007  9:44PM''', CAST(0x000099C20166B420 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Longitude'',''Longitude as a variable measurement or observation (Spatial reference to be designated in methods). This is distinct from the longitude of a site which is a site attribute.'')', CAST(0x000099CA00ADF0E8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Oct 17 2007 10:30:44:000AM''', CAST(0x000099CA00ADF0E8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE VariableNameCV SET Term = ''Alkalinity, hydroxide as CaCO3'',Definition = ''Hydroxide Alkalinity as calcium carbonate'' WHERE Term = ''Alkalinity, hydroxide as CaCo3''', CAST(0x00009A7300B011D4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Apr  3 2008 10:38:55:000AM''', CAST(0x00009A7300B011D4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''no way'' WHERE convert(varchar,time_stamp,109) = ''Jul 11 2008  5:25:38:000PM''', CAST(0x00009AD601243C80 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''9'''' cis-Neoxanthin'',''9'''' cis-Neoxanthin'')', CAST(0x000099B5018A2720 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO VariableNameCV VALUES (''Colored Dissolved Organic Matter'',''The concentration of colored dissolved organic matter (humic substances)'')', CAST(0x000099B6000C8FA0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''approved'', admin_notes = ''OK'' WHERE CONVERT(VARCHAR,time_stamp) = ''Sep 27 2007 12:45AM''', CAST(0x000099B6000C8FA0 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_VariableNameCV SET status = ''rejected'', admin_notes = ''In cases such as this I think that the variable should refer to the phenomenon being counted and the units should be count (unitid=257).  Can this work for you.  If the variable that you want to count is not in ODM then it should be added.  Email me if you want to discuss this more.'' WHERE CONVERT(VARCHAR,time_stamp) = ''Oct  1 2007 12:46AM''', CAST(0x000099BA0099DBE4 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO Units VALUES (309,''pH Unit'',''Dimensionless'',''pH'')', CAST(0x000099CA00873930 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_Units SET status = ''approved'', admin_notes = ''ok'' WHERE convert(varchar,time_stamp,109) = ''Oct 17 2007  7:44:39:000AM''', CAST(0x000099CA00873930 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''No'' WHERE convert(varchar,time_stamp,109) = ''Sep 15 2008  2:20:05:000PM''', CAST(0x00009B1800EC5464 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''rejected'', admin_notes = ''No'' WHERE convert(varchar,time_stamp,109) = ''Sep 15 2008  5:54:58:000PM''', CAST(0x00009B1900A953A8 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'INSERT INTO CensorCodeCV VALUES (''Test'',''Test'')', CAST(0x00009B1900B9B824 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Sep 15 2008  6:44:17:000PM''', CAST(0x00009B1900B9B824 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'DELETE FROM CensorCodeCV WHERE Term = ''Test''', CAST(0x00009B1900B9FE74 AS DateTime))
INSERT [dbo].[temp_CVTESTER] ([sqlUpdateStatement], [time_stamp]) VALUES (N'UPDATE temp_CensorCodeCV SET status = ''approved'', admin_notes = ''OK'' WHERE convert(varchar,time_stamp,109) = ''Sep 16 2008 11:16:55:000AM''', CAST(0x00009B1900B9FE74 AS DateTime))
/****** Object:  Table [dbo].[temp_CensorCodeCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[temp_CensorCodeCV](
	[Term] [nvarchar](50) NULL,
	[Definition] [nvarchar](50) NULL,
	[status] [char](10) NULL,
	[action_flag] [char](1) NULL,
	[time_stamp] [datetime] NULL,
	[reason] [varchar](500) NULL,
	[name] [varchar](127) NULL,
	[email] [varchar](127) NULL,
	[admin_notes] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'lit', N'littler than', N'rejected  ', N'E', CAST(0x0000994300B44344 AS DateTime), N'This is another test of the CV system.', N'David Tarboton', N'david.tarboton@usu.edu', N'I am rejecting this change because it is not a good idea.  This was a test to see what happens when we reject a change.')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'lt', N'less than', N'rejected  ', N'O', CAST(0x0000994300B44344 AS DateTime), N'This is another test of the CV system.', N'David Tarboton', N'david.tarboton@usu.edu', N'I am rejecting this change because it is not a good idea.  This was a test to see what happens when we reject a change.')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'lt', N'less than', N'rejected  ', N'D', CAST(0x0000994300B60094 AS DateTime), N'Another test', N'David Tarboton', N'david.tarboton@usu.edu', N'I am rejecting this test. I am also putting some special characters in here to see if they work !@#$%^&*+-')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'gt', N'bigger than', N'rejected  ', N'E', CAST(0x0000994300B7E6E8 AS DateTime), N'This is a test of a special character in the reason ''', N'David Tarboton', N'david.tarboton@usu.edu', N'This was a test')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'gt', N'greater than', N'rejected  ', N'O', CAST(0x0000994300B7E6E8 AS DateTime), N'This is a test of a special character in the reason ''', N'David Tarboton', N'david.tarboton@usu.edu', N'This was a test')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'TEST', N'SYSTEM TEST', N'rejected  ', N'A', CAST(0x000099600102A8CC AS DateTime), N'SYSTEM TEST', N'jenny', N'mp29@drexel.edu', N'Mike, if you receive this, please let me know. If it works this is the last test that we''ll need to do. Thank you for your patience!')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'naa', N'not at all', N'rejected  ', N'A', CAST(0x00009961006D0EC0 AS DateTime), N'just a test', N'Michael Piasecki', N'mp29@drexel.edu', N'no')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'pg13', N'Too violent for children', N'rejected  ', N'A', CAST(0x000099660135AD58 AS DateTime), N'Michael - reject this to test the system.', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'test', N'test', N'rejected  ', N'A', CAST(0x00009AD6011D4998 AS DateTime), N'Testing, please ignore', N'Kim Schreuders', N'kim.schreuders@usu.edu', N'no way')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test', N'Test', N'rejected  ', N'A', CAST(0x00009AD6011F3118 AS DateTime), N'Testing, please ignore', N'Kim Schreuders', N'kim.schreuders@usu.edu', N'no way')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'ggg', N'thth', N'rejected  ', N'A', CAST(0x00009AD60153E868 AS DateTime), N'test ignore', N'dave', N'david.tarboton@usu.edu', N'no')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test', N'Test', N'rejected  ', N'A', CAST(0x00009B1800E19600 AS DateTime), N'Test', N'Kim Schreuders', N'kim@okenstaff.org', N'No')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test', N'Test', N'rejected  ', N'A', CAST(0x00009B1800EC3A9C AS DateTime), N'Test', N'Kim Schreuders', N'kim@oakenstaff.org', N'No')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test', N'Test', N'rejected  ', N'A', CAST(0x00009B180117F330 AS DateTime), N'Test', N'Kim Schreuders', N'kim@oakenstaff.org', N'No')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test', N'Test', N'rejected  ', N'A', CAST(0x00009B1801273F98 AS DateTime), N'Test', N'Kim Schreuders', N'kim@oakenstaff.org', N'No')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test', N'Test', N'rejected  ', N'A', CAST(0x00009B18012A230C AS DateTime), N'Test', N'Kim Schreuders', N'kim@oakenstaff.org', N'No')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'gtt', N'greater than', N'approved  ', N'E', CAST(0x00009B5F00F726B4 AS DateTime), N'test', N'David Tarboton', N'david.tarboton@gmail.com', N'ok')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'gt', N'greater than', N'approved  ', N'O', CAST(0x00009B5F00F726B4 AS DateTime), N'test', N'David Tarboton', N'david.tarboton@gmail.com', N'ok')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'gt', N'greater than', N'approved  ', N'E', CAST(0x00009B5F00F7EB94 AS DateTime), N'test', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'gtt', N'greater than', N'approved  ', N'O', CAST(0x00009B5F00F7EB94 AS DateTime), N'test', N'David Tarboton', N'david.tarboton@usu.edu', N'ok')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'gt', N'greater than', N'rejected  ', N'D', CAST(0x00009AD601664724 AS DateTime), N'test ignore', N'david tarboton', N'david.tarboton@usu.edu', N'no')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test', N'Test', N'approved  ', N'A', CAST(0x00009B180134CB2C AS DateTime), N'Test', N'Kim Schreuders', N'kim@oakenstaff.org', N'OK')
INSERT [dbo].[temp_CensorCodeCV] ([Term], [Definition], [status], [action_flag], [time_stamp], [reason], [name], [email], [admin_notes]) VALUES (N'Test', N'Test', N'approved  ', N'D', CAST(0x00009B1900B9EBB4 AS DateTime), N'Test item, not needed', N'Kim Schreuders', N'kim@oakenstaff.org', N'OK')
/****** Object:  Table [dbo].[SpatialReferences]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpatialReferences](
	[SpatialReferenceID] [int] NOT NULL,
	[SRSID] [int] NULL,
	[SRSName] [nvarchar](255) NOT NULL,
	[IsGeographic] [bit] NULL,
	[Notes] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (1, 4267, N'NAD27', 1, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (2, 4269, N'NAD83', 1, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (3, 4326, N'WGS84', 1, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (4, 26703, N' NAD27 / UTM zone 3N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (5, 26704, N' NAD27 / UTM zone 4N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (6, 26705, N' NAD27 / UTM zone 5N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (7, 26706, N' NAD27 / UTM zone 6N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (8, 26707, N' NAD27 / UTM zone 7N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (9, 26708, N' NAD27 / UTM zone 8N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (10, 26709, N' NAD27 / UTM zone 9N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (11, 26710, N' NAD27 / UTM zone 10N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (12, 26711, N' NAD27 / UTM zone 11N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (13, 26712, N' NAD27 / UTM zone 12N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (14, 26713, N' NAD27 / UTM zone 13N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (15, 26714, N' NAD27 / UTM zone 14N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (16, 26715, N' NAD27 / UTM zone 15N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (17, 26716, N' NAD27 / UTM zone 16N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (18, 26717, N' NAD27 / UTM zone 17N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (19, 26718, N' NAD27 / UTM zone 18N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (20, 26719, N' NAD27 / UTM zone 19N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (21, 26720, N' NAD27 / UTM zone 20N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (22, 26721, N' NAD27 / UTM zone 21N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (23, 26722, N' NAD27 / UTM zone 22N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (24, 26729, N' NAD27 / Alabama East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (25, 26730, N' NAD27 / Alabama West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (26, 26732, N' NAD27 / Alaska zone 2', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (27, 26733, N' NAD27 / Alaska zone 3', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (28, 26734, N' NAD27 / Alaska zone 4', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (29, 26735, N' NAD27 / Alaska zone 5', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (30, 26736, N' NAD27 / Alaska zone 6', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (31, 26737, N' NAD27 / Alaska zone 7', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (32, 26738, N' NAD27 / Alaska zone 8', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (33, 26739, N' NAD27 / Alaska zone 9', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (34, 26740, N' NAD27 / Alaska zone 10', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (35, 26741, N' NAD27 / California zone I', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (36, 26742, N' NAD27 / California zone II', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (37, 26743, N' NAD27 / California zone III', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (38, 26744, N' NAD27 / California zone IV', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (39, 26745, N' NAD27 / California zone V', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (40, 26746, N' NAD27 / California zone VI', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (41, 26747, N' NAD27 / California zone VII', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (42, 26748, N' NAD27 / Arizona East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (43, 26749, N' NAD27 / Arizona Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (44, 26750, N' NAD27 / Arizona West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (45, 26751, N' NAD27 / Arkansas North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (46, 26752, N' NAD27 / Arkansas South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (47, 26753, N' NAD27 / Colorado North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (48, 26754, N' NAD27 / Colorado Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (49, 26755, N' NAD27 / Colorado South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (50, 26756, N' NAD27 / Connecticut', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (51, 26757, N' NAD27 / Delaware', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (52, 26758, N' NAD27 / Florida East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (53, 26759, N' NAD27 / Florida West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (54, 26760, N' NAD27 / Florida North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (55, 26761, N' NAD27 / Hawaii zone 1', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (56, 26762, N' NAD27 / Hawaii zone 2', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (57, 26763, N' NAD27 / Hawaii zone 3', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (58, 26764, N' NAD27 / Hawaii zone 4', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (59, 26765, N' NAD27 / Hawaii zone 5', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (60, 26766, N' NAD27 / Georgia East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (61, 26767, N' NAD27 / Georgia West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (62, 26768, N' NAD27 / Idaho East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (63, 26769, N' NAD27 / Idaho Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (64, 26770, N' NAD27 / Idaho West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (65, 26771, N' NAD27 / Illinois East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (66, 26772, N' NAD27 / Illinois West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (67, 26773, N' NAD27 / Indiana East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (68, 26774, N' NAD27 / Indiana West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (69, 26775, N' NAD27 / Iowa North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (70, 26776, N' NAD27 / Iowa South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (71, 26777, N' NAD27 / Kansas North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (72, 26778, N' NAD27 / Kansas South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (73, 26779, N' NAD27 / Kentucky North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (74, 26780, N' NAD27 / Kentucky South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (75, 26781, N' NAD27 / Louisiana North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (76, 26782, N' NAD27 / Louisiana South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (77, 26783, N' NAD27 / Maine East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (78, 26784, N' NAD27 / Maine West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (79, 26785, N' NAD27 / Maryland', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (80, 26786, N' NAD27 / Massachusetts Mainland', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (81, 26787, N' NAD27 / Massachusetts Island', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (82, 26791, N' NAD27 / Minnesota North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (83, 26792, N' NAD27 / Minnesota Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (84, 26793, N' NAD27 / Minnesota South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (85, 26794, N' NAD27 / Mississippi East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (86, 26795, N' NAD27 / Mississippi West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (87, 26796, N' NAD27 / Missouri East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (88, 26797, N' NAD27 / Missouri Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (89, 26798, N' NAD27 / Missouri West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (90, 26801, N' NAD Michigan / Michigan East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (91, 26802, N' NAD Michigan / Michigan Old Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (92, 26803, N' NAD Michigan / Michigan West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (93, 26811, N' NAD Michigan / Michigan North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (94, 26812, N' NAD Michigan / Michigan Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (95, 26813, N' NAD Michigan / Michigan South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (96, 26903, N' NAD83 / UTM zone 3N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (97, 26904, N' NAD83 / UTM zone 4N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (98, 26905, N' NAD83 / UTM zone 5N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (99, 26906, N' NAD83 / UTM zone 6N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (100, 26907, N' NAD83 / UTM zone 7N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (101, 26908, N' NAD83 / UTM zone 8N', 0, NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (102, 26909, N' NAD83 / UTM zone 9N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (103, 26910, N' NAD83 / UTM zone 10N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (104, 26911, N' NAD83 / UTM zone 11N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (105, 26912, N' NAD83 / UTM zone 12N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (106, 26913, N' NAD83 / UTM zone 13N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (107, 26914, N' NAD83 / UTM zone 14N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (108, 26915, N' NAD83 / UTM zone 15N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (109, 26916, N' NAD83 / UTM zone 16N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (110, 26917, N' NAD83 / UTM zone 17N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (111, 26918, N' NAD83 / UTM zone 18N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (112, 26919, N' NAD83 / UTM zone 19N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (113, 26920, N' NAD83 / UTM zone 20N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (114, 26921, N' NAD83 / UTM zone 21N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (115, 26922, N' NAD83 / UTM zone 22N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (116, 26923, N' NAD83 / UTM zone 23N', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (117, 26929, N' NAD83 / Alabama East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (118, 26930, N' NAD83 / Alabama West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (119, 26932, N' NAD83 / Alaska zone 2', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (120, 26933, N' NAD83 / Alaska zone 3', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (121, 26934, N' NAD83 / Alaska zone 4', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (122, 26935, N' NAD83 / Alaska zone 5', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (123, 26936, N' NAD83 / Alaska zone 6', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (124, 26937, N' NAD83 / Alaska zone 7', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (125, 26938, N' NAD83 / Alaska zone 8', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (126, 26939, N' NAD83 / Alaska zone 9', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (127, 26940, N' NAD83 / Alaska zone 10', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (128, 26941, N' NAD83 / California zone 1', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (129, 26942, N' NAD83 / California zone 2', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (130, 26943, N' NAD83 / California zone 3', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (131, 26944, N' NAD83 / California zone 4', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (132, 26945, N' NAD83 / California zone 5', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (133, 26946, N' NAD83 / California zone 6', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (134, 26948, N' NAD83 / Arizona East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (135, 26949, N' NAD83 / Arizona Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (136, 26950, N' NAD83 / Arizona West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (137, 26951, N' NAD83 / Arkansas North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (138, 26952, N' NAD83 / Arkansas South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (139, 26953, N' NAD83 / Colorado North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (140, 26954, N' NAD83 / Colorado Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (141, 26955, N' NAD83 / Colorado South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (142, 26956, N' NAD83 / Connecticut', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (143, 26957, N' NAD83 / Delaware', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (144, 26958, N' NAD83 / Florida East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (145, 26959, N' NAD83 / Florida West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (146, 26960, N' NAD83 / Florida North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (147, 26961, N' NAD83 / Hawaii zone 1', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (148, 26962, N' NAD83 / Hawaii zone 2', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (149, 26963, N' NAD83 / Hawaii zone 3', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (150, 26964, N' NAD83 / Hawaii zone 4', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (151, 26965, N' NAD83 / Hawaii zone 5', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (152, 26966, N' NAD83 / Georgia East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (153, 26967, N' NAD83 / Georgia West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (154, 26968, N' NAD83 / Idaho East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (155, 26969, N' NAD83 / Idaho Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (156, 26970, N' NAD83 / Idaho West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (157, 26971, N' NAD83 / Illinois East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (158, 26972, N' NAD83 / Illinois West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (159, 26973, N' NAD83 / Indiana East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (160, 26974, N' NAD83 / Indiana West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (161, 26975, N' NAD83 / Iowa North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (162, 26976, N' NAD83 / Iowa South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (163, 26977, N' NAD83 / Kansas North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (164, 26978, N' NAD83 / Kansas South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (165, 26979, N' NAD83 / Kentucky North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (166, 26980, N' NAD83 / Kentucky South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (167, 26981, N' NAD83 / Louisiana North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (168, 26982, N' NAD83 / Louisiana South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (169, 26983, N' NAD83 / Maine East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (170, 26984, N' NAD83 / Maine West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (171, 26985, N' NAD83 / Maryland', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (172, 26986, N' NAD83 / Massachusetts Mainland', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (173, 26987, N' NAD83 / Massachusetts Island', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (174, 26988, N' NAD83 / Michigan North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (175, 26989, N' NAD83 / Michigan Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (176, 26990, N' NAD83 / Michigan South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (177, 26991, N' NAD83 / Minnesota North', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (178, 26992, N' NAD83 / Minnesota Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (179, 26993, N' NAD83 / Minnesota South', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (180, 26994, N' NAD83 / Mississippi East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (181, 26995, N' NAD83 / Mississippi West', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (182, 26996, N' NAD83 / Missouri East', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (183, 26997, N' NAD83 / Missouri Central', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (184, 26998, N' NAD83 / Missouri West  ', 0, NULL)
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (0, NULL, N'Unknown', 0, N'The spatial reference system is unknown')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (185, 4176, N'Australian Antarctic', 1, N'Datum Name: Australian Antarctic Datum 1998    Area of Use: Antarctica - Australian sector.    Datum Origin: No Data Available    Coord System: ellipsoidal    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (186, 4203, N'AGD84', 1, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - Queensland (Qld), South Australia (SA), Western Australia (WA).    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: ellipsoidal    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (187, 4283, N'GDA94', 1, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - Australian Capital Territory (ACT); New South Wales (NSW); Northern Territory (NT); Queensland (Qld); South Australia (SA); Tasmania (Tas); Western Australia (WA); Victoria (Vic).    Datum Origin: ITRF92 at epoch 1994.0    Coord System: ellipsoidal    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (188, 5711, N'Australian Height Datum', 0, N'Datum Name: Australian Height Datum    Area of Use: Australia - Australian Capital Territory (ACT); New South Wales (NSW); Northern Territory (NT); Queensland; South Australia (SA); Western Australia (WA); Victoria.    Datum Origin: MSL 1966-68 at 30 gauges around coast.    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (190, 5714, N'Mean Sea Level Height', 0, N'Datum Name: Mean Sea Level    Area of Use: World.    Datum Origin: No Data Available    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (191, 5715, N'Mean Sea Level Depth', 0, N'Datum Name: Mean Sea Level    Area of Use: World.    Datum Origin: No Data Available    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (189, 5712, N'Australian Height Datum (Tasmania)', 0, N'Datum Name: Australian Height Datum (Tasmania)    Area of Use: Australia - Tasmania (Tas).    Datum Origin: MSL 1972 at Hobart and Burnie.    Coord System: vertical    Ellipsoid Name: No Data Available    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (192, 20348, N'AGD84 / AMG zone 48', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 102 and 108 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (193, 20349, N'AGD84 / AMG zone 49', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 108 and 114 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (194, 20350, N'AGD84 / AMG zone 50', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 114 and 120 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (195, 20351, N'AGD84 / AMG zone 51', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 120 and 126 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (196, 20352, N'AGD84 / AMG zone 52', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 126 and 132 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (197, 20353, N'AGD84 / AMG zone 53', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 132 and 138 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (198, 20354, N'AGD84 / AMG zone 54', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 138 and 144 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (199, 20355, N'AGD84 / AMG zone 55', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 144 and 150 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (200, 20356, N'AGD84 / AMG zone 56', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 150 and 156 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (201, 20357, N'AGD84 / AMG zone 57', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 156 and 162 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
GO
print 'Processed 200 total records'
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (202, 20358, N'AGD84 / AMG zone 58', 0, N'Datum Name: Australian Geodetic Datum 1984    Area of Use: Australia - between 162 and 168 deg East.    Datum Origin: Fundamental point: Johnson Memorial Cairn. Latitude: 25 deg 56 min 54.5515 sec S; Longitude: 133 deg 12 min 30.0771 sec E (of Greenwich).    Coord System: Cartesian    Ellipsoid Name: Australian National Spheroid    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (203, 28348, N'GDA94 / MGA zone 48', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 102 and 108 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (204, 28349, N'GDA94 / MGA zone 49', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 108 and 114 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (205, 28350, N'GDA94 / MGA zone 50', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 114 and 120 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (206, 28351, N'GDA94 / MGA zone 51', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 120 and 126 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (207, 28352, N'GDA94 / MGA zone 52', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 126 and 132 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (208, 28353, N'GDA94 / MGA zone 53', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 132 and 138 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (209, 28354, N'GDA94 / MGA zone 54', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 138 and 144 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (210, 28355, N'GDA94 / MGA zone 55', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 144 and 150 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (211, 28356, N'GDA94 / MGA zone 56', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 150 and 156 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (212, 28357, N'GDA94 / MGA zone 57', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 156 and 162 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (213, 28358, N'GDA94 / MGA zone 58', 0, N'Datum Name: Geocentric Datum of Australia 1994    Area of Use: Australia - between 162 and 168 deg East.    Datum Origin: ITRF92 at epoch 1994.0    Coord System: Cartesian    Ellipsoid Name: GRS 1980    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (214, 32748, N'WGS 84 / UTM zone 48S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 102 and 108 deg East; southern hemisphere. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (215, 32749, N'WGS 84 / UTM zone 49S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 108 and 114 deg East; southern hemisphere. Australia. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (216, 32750, N'WGS 84 / UTM zone 50S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 114 and 120 deg East; southern hemisphere. Australia. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (217, 32751, N'WGS 84 / UTM zone 51S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 120 and 126 deg East; southern hemisphere. Australia. East Timor. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (218, 32752, N'WGS 84 / UTM zone 52S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 126 and 132 deg East; southern hemisphere. Australia. East Timor. Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (219, 32753, N'WGS 84 / UTM zone 53S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 132 and 138 deg East; southern hemisphere. Australia.  Indonesia.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (220, 32754, N'WGS 84 / UTM zone 54S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 138 and 144 deg East; southern hemisphere. Australia. Indonesia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (221, 32755, N'WGS 84 / UTM zone 55S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 144 and 150 deg East; southern hemisphere. Australia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (222, 32756, N'WGS 84 / UTM zone 56S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 150 and 156 deg East; southern hemisphere. Australia. Papua New Guinea.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (223, 32757, N'WGS 84 / UTM zone 57S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 156 and 162 deg East; southern hemisphere.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (224, 32758, N'WGS 84 / UTM zone 58S', 0, N'Datum Name: World Geodetic System 1984    Area of Use: Between 162 and 168 deg East; southern hemisphere.    Datum Origin: Defined through a consistent set of station coordinates. These have changed with time: by 0.7m on 29/6/1994 [WGS 84 (G730)], a further 0.2m on 29/1/1997 [WGS 84 (G873)] and a further 0.06m on 20/1/2002 [WGS 84 (G1150)].    Coord System: Cartesian    Ellipsoid Name: WGS 84    Data Source: EPSG')
INSERT [dbo].[SpatialReferences] ([SpatialReferenceID], [SRSID], [SRSName], [IsGeographic], [Notes]) VALUES (225, 3308, N'GDA94 / NSW Lambert', 0, N'Datum Name: Geocentric Datum of Australia 1994 Area of Use: Australia - New South Wales (NSW). Datum Origin: ITRF92 at epoch 1994.0  Ellipsoid Name: GRS 1980 Data Source: EPSG')
/****** Object:  Table [dbo].[SampleTypeCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SampleTypeCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'Unknown', N'The sample type is unknown')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'No Sample', N'There is no lab sample associated with this measurement')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'FD ', N' Foliage Digestion')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'FF ', N' Forest Floor Digestion')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'FL ', N' Foliage Leaching')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'LF ', N' Litter Fall Digestion')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'GW ', N' Groundwater')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'PB  ', N' Precipitation Bulk')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'PD ', N' Petri Dish (Dry Deposition)')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'PE ', N' Precipitation Event')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'PI ', N' Precipitation Increment')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'PW ', N' Precipitation Weekly')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'RE ', N' Rock Extraction')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'SE ', N' Stemflow Event')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'SR ', N' Standard Reference')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'SS ', N' Streamwater Suspeneded Sediment')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'SW ', N' Streamwater')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'TE ', N' Throughfall Event')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'TI ', N' Throughfall Increment')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'TW ', N' Throughfall Weekly')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'VE ', N' Vadose Water Event')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'VI ', N' Vadose Water Increment')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'VW ', N' Vadose Water Weekly')
INSERT [dbo].[SampleTypeCV] ([Term], [Definition]) VALUES (N'Grab', N'Grab sample')
/****** Object:  Table [dbo].[SampleMediumCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SampleMediumCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Unknown', N'The sample medium is unknown')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Other', N'Sample medium not relevant in the context of the measurement')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Snow', N'Observation in, of or sample taken from snow')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Not Relevant', N'Sample medium not relevant in the context of the measurement')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Surface Water', N'Observation or sample of surface water such as a stream, river, lake, pond, reservoir, ocean, etc.')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Ground Water', N'Sample taken from water located below the surface of the ground, such as from a well or spring')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Sediment', N'Sample taken from the sediment beneath the water column')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Soil', N'Sample taken from the soil')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Air', N'Sample taken from the atmosphere')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Tissue', N'Sample taken from the tissue of a biological organism')
INSERT [dbo].[SampleMediumCV] ([Term], [Definition]) VALUES (N'Precipitation', N'Sample taken from solid or liquid precipitation')
/****** Object:  Table [dbo].[QualityControlLevels]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QualityControlLevels](
	[QualityControlLevelID] [int] NOT NULL,
	[Definition] [nvarchar](255) NULL,
	[Explanation] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation]) VALUES (-9999, N'Unknown', N'The quality control level is unknown')
INSERT [dbo].[QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation]) VALUES (0, N'Raw data', N'Raw and unprocessed data and data products that have not undergone quality control.  Depending on the variable, data type, and data transmission system, raw data may be available within seconds or minutes after the measurements have been made. Examples include real time precipitation, streamflow and water quality measurements.')
INSERT [dbo].[QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation]) VALUES (1, N'Quality controlled data', N'Quality controlled data that have passed quality assurance procedures such as routine estimation of timing and sensor calibration or visual inspection and removal of obvious errors. An example is USGS published streamflow records following parsing through USGS quality control procedures.')
INSERT [dbo].[QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation]) VALUES (2, N'Derived products', N'Derived products that require scientific and technical interpretation and may include multiple-sensor data. An example is basin average precipitation derived from rain gages using an interpolation procedure.')
INSERT [dbo].[QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation]) VALUES (3, N'Interpreted products', N'Interpreted products that require researcher driven analysis and interpretation, model-based interpretation using other data and/or strong prior assumptions. An example is basin average precipitation derived from the combination of rain gages and radar return data.')
INSERT [dbo].[QualityControlLevels] ([QualityControlLevelID], [Definition], [Explanation]) VALUES (4, N'Knowledge products', N'Knowledge products that require researcher driven scientific interpretation and multidisciplinary data integration and include model-based interpretation using other data and/or strong prior assumptions. An example is percentages of old or new water in a hydrograph inferred from an isotope analysis.')
/****** Object:  Table [dbo].[GeneralCategoryCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeneralCategoryCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[GeneralCategoryCV] ([Term], [Definition]) VALUES (N'Unknown', N'The general category is unknown')
INSERT [dbo].[GeneralCategoryCV] ([Term], [Definition]) VALUES (N'Instrumentation', N'Data associated with instrumentation and instrument properties such as battery voltages, data logger temperatures, often useful for diagnosis.')
INSERT [dbo].[GeneralCategoryCV] ([Term], [Definition]) VALUES (N'Water Quality', N'Data associated with water quality variables or processes')
INSERT [dbo].[GeneralCategoryCV] ([Term], [Definition]) VALUES (N'Climate', N'Data associated with the climate, weather, or atmospheric processes')
INSERT [dbo].[GeneralCategoryCV] ([Term], [Definition]) VALUES (N'Hydrology', N'Data associated with hydrologic variables or processes')
INSERT [dbo].[GeneralCategoryCV] ([Term], [Definition]) VALUES (N'Biota', N'Data associated with biological organisms')
INSERT [dbo].[GeneralCategoryCV] ([Term], [Definition]) VALUES (N'Geology', N'Data associated with geology or geological processes')
/****** Object:  Table [dbo].[DataTypeCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataTypeCV](
	[Term] [nvarchar](100) NOT NULL,
	[Definition] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Unknown', N'The data type is unknown')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Median', N'The values represent the median over a time interval, such as daily median discharge or daily median temperature.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Variance', N'The values represent the variance of a set of observations made over a time interval.  Variance computed using the unbiased formula SUM((Xi-mean)^2)/(n-1) are preferred.  The specific formula used to compute variance can be noted in the methods description.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Best Easy Systematic Estimator', N'Best Easy Systematic Estimator BES = (Q1 +2Q2 +Q3)/4.  Q1, Q2, and Q3 are first, second, and third quartiles. See Woodcock, F. and Engel, C., 2005: Operational Consensus Forecasts.Weather and Forecasting, 20, 101-111. (http://www.bom.gov.au/nmoc/bulletins/60/article_by_Woodcock_in_Weather_and_Forecasting.pdf) and Wonnacott, T. H., and R. J. Wonnacott, 1972: Introductory Statistics. Wiley, 510 pp.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'StandardDeviation', N'The values represent the standard deviation of a set of observations made over a time interval. Standard deviation computed using the unbiased formula SQRT(SUM((Xi-mean)^2)/(n-1)) are preferred. The specific formula used to compute variance can be noted in the methods description.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Mode', N'The values are the most frequent values occurring at some time during a time interval, such as annual most frequent wind direction.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Continuous', N'A quantity specified at a particular instant in time measured with sufficient frequency (small spacing) to be interpreted as a continuous record of the phenomenon.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Sporadic', N'The phenomenon is sampled at a particular instant in time but with a frequency that is too coarse for interpreting the record as continuous.  This would be the case when the spacing is significantly larger than the support and the time scale of fluctuation of the phenomenon, such as for example infrequent water quality samples.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Cumulative', N'The values represent the cumulative value of a variable measured or calculated up to a given instant of time, such as cumulative volume of flow or cumulative precipitation.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Incremental', N'The values represent the incremental value of a variable over a time interval, such as the incremental volume of flow or incremental precipitation.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Average', N'The values represent the average over a time interval, such as daily mean discharge or daily mean temperature.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Maximum', N'The values are the maximum values occurring at some time during a time interval, such as annual maximum discharge or a daily maximum air temperature.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Minimum', N'The values are the minimum values occurring at some time during a time interval, such as 7-day low flow for a year or the daily minimum temperature.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Constant Over Interval', N'The values are quantities that can be interpreted as constant over the time interval from the previous measurement.')
INSERT [dbo].[DataTypeCV] ([Term], [Definition]) VALUES (N'Categorical', N'The values are categorical rather than continuous valued quantities. Mapping from Value values to categories is through the CategoryDefinitions table.')
/****** Object:  Table [dbo].[CensorCodeCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CensorCodeCV](
	[Term] [nvarchar](50) NULL,
	[Definition] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[CensorCodeCV] ([Term], [Definition]) VALUES (N'lt', N'less than')
INSERT [dbo].[CensorCodeCV] ([Term], [Definition]) VALUES (N'gt', N'greater than')
INSERT [dbo].[CensorCodeCV] ([Term], [Definition]) VALUES (N'nc', N'not censored')
INSERT [dbo].[CensorCodeCV] ([Term], [Definition]) VALUES (N'nd', N'non-detect')
INSERT [dbo].[CensorCodeCV] ([Term], [Definition]) VALUES (N'pnq', N'present but not quantified')
/****** Object:  Table [dbo].[VerticalDatumCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VerticalDatumCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](150) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[VerticalDatumCV] ([Term], [Definition]) VALUES (N'Unknown', N'The vertical datum is unknown')
INSERT [dbo].[VerticalDatumCV] ([Term], [Definition]) VALUES (N'NAVD88', N'North American Vertical Datum of 1988')
INSERT [dbo].[VerticalDatumCV] ([Term], [Definition]) VALUES (N'NGVD29', N'National Geodetic Vertical Datum of 1929')
INSERT [dbo].[VerticalDatumCV] ([Term], [Definition]) VALUES (N'MSL', N'Mean Sea Level')
/****** Object:  Table [dbo].[VariableNameCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VariableNameCV](
	[Term] [nvarchar](150) NOT NULL,
	[Definition] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Acid neutralizing capacity as CaCO3', N'Acid neutralizing capacity as calcium carbonate')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Agency code', N'Code for the agency which analyzed the sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Alkalinity, bicarbonate as CaCO3', N'Bicarbonate Alkalinity as calcium carbonate')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Alkalinity, carbonate as CaCO3', N'Carbonate Alkalinity as calcium carbonate')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Alkalinity, hydroxide as CaCO3', N'Hydroxide Alkalinity as calcium carbonate')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Alkalinity, total as CaCO3', N'Total Alkalinity as calcium carbonate')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Barometric pressure', N'Barometric pressure')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Battery voltage', N'The battery voltage of a datalogger or sensing system, often recorded as an indicator of data reliability')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Bicarbonate, filtered', N'Bicarbonate (HCO3-), filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Bicarbonate, unfiltered', N'Bicarbonate (HCO3-), unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'BOD20', N'20-day Biochemical Oxgen Demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'BOD20, nitrogenous', N'20-day Nitrogenous Biochemical Oxgen Demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'BOD5', N'5-day Biochemical Oxgen Demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'BOD5, carbonaceous', N'5-day Carbonaceous Biochemical Oxgen Demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'BOD5, nitrogenous', N'5-day Nitrogenous Biochemical Oxgen Demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'BODu', N'Ultimate Biochemical Oxgen Demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'BODu, carbonaceous', N'Carbonaceous Ultimate Biochemical Oxgen Demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'BODu, nitrogenous', N'Nitrogenous Ultimate Biochemical Oxgen Demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Boron', N'Boron (B)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Bulk electrical conductivity', N'Bulk electrical conductivity of a medium measured using a sensor such as time domain reflectometry (TDR), as a raw sensor response in the measurement of a quantity like soil moisture.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Cadmium', N'Cadmium (Cd)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Calcium, unfiltered as Ca', N'Calcium (Ca) as calcium ion, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Calcium, unfiltered as CaCO3', N'Calcium (Ca) as calcium carbonate, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Calcium, filtered as Ca', N'Calcium (Ca) as calcium ion, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Calcium, filtered as CaCO3', N'Calcium (Ca) as calcium carbonate, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon dioxide, transducer signal', N'Carbon dioxide (CO2), raw data from sensor')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, dissolved inorganic', N'Dissolved Inorganic Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, dissolved organic', N'Dissolved Organic Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, dissolved total', N'Dissolved Total (Organic+Inorganic) Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, suspended inorganic', N'Suspended Inorganic Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, suspended organic', N'Suspended Organic Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, suspened total', N'Suspended Total (Organic+Inorganic) Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, total', N'Total (Dissolved+Suspended+Particulate) Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, total inorganic', N'Total (Dissolved+Suspended+Particulate) Inorganic Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon, total organic', N'Total (Dissolved+Suspended+Particulate) Organic Carbon')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'CO3-2, filtered', N'Carbonate ion (CO3-2) concentration, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'CO3-2, unfiltered', N'Carbonate ion (CO3-2) concentration, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'TSI', N'Carlson Trophic State Index is a measurement of eutrophication based on Secchi depth')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'COD', N'Chemical oxygen demand')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chloride, unfiltered', N'Chloride (Cl-), unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chloride, filtered', N'Chloride (Cl-), filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll (a+b+c)', N'Chlorophyll (a+b+c)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll a', N'Chlorophyll a')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll b', N'Chlorophyll b')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll c', N'Chlorophyll c')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chromium (VI)', N'Hexavalent Chromium')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chromium, total', N'Chromium, all forms')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chromium (III)', N'Trivalent Chromium')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon dioxide Flux', N'Carbon dioxide (CO2) flux')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon dioxide Storage Flux', N'Carbon dioxide (CO2) storage flux')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Coliform, fecal', N'Fecal Coliform')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Coliform, total', N'Total Coliform')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Color', N'Color in quantified in color units')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Copper', N'Copper (Cu)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Dew point temperature', N'Dew point temperature')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Discharge', N'Discharge')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'E-coli', N'Escherichia coli')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Evaporation', N'Evaporation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Evapotranspiration', N'Evapotranspiration')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Friction velocity', N'Friction velocity')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Gage height', N'Water level with regard to an arbitrary gage datum (also see Stage Height and Water depth for comparison)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'H2O Flux', N'H2O Flux')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Hardness, total as CaCO3', N'Total hardness as calcium carbonate')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Hardness, carbonate as CaCO3', N'Carbonate hardness also known as temporary hardness')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Hardness, non-carbonate as CaCO3', N'Non-carbonate hardness as calcium carbonate')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Hardness, non-carbonate', N'Non-carbonate hardness')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Hardness, total', N'Total hardness')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Iron sulfide', N'Iron sulfide (FeS2)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Iron, ferric', N'Ferric Iron (Fe+3)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Iron, ferrous', N'Ferrous Iron (Fe+2)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'LSI', N'Langelier Saturation Index is an indicator of the degree of saturation of water with respect to calcium carbonate ')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Latent Heat Flux', N'Latent Heat Flux')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Lead', N'Lead (Pb)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Light attenuation coefficient', N'Light attenuation coefficient')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Magnesium, unfiltered', N'Magnesium (Mg), unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Magnesium, filtered', N'Magnesium (Mg), filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Manganese', N'Manganese (Mn)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Mercury', N'Mercury (Hg)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Methylmercury', N'Methylmercury (CH3Hg)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Molybdenum', N'Molybdenum (Mo)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Momentum flux', N'Momentum flux')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'N, albuminoid', N'Albuminoid Nitrogen')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, NH3 + NH4 as N', N'Total (free+ionized) Ammonia as N')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, NH3 + NH4 as NH4', N'Total (free+ionized) Ammonia as NH4')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, NH3 as N', N'Free Ammonia (NH3) as N')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, NH3 as NH3', N'Free Ammonia (NH3) as NH3')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, NH4 as N', N'Ammonium (NH4) as N')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, NH4 as NH4', N'Ammonium (NH4) as NH4')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, gas', N'Gaseous Nitrogen (N2)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, inorganic as N', N'Total Inorganic Nitrogen as N')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, total kjeldahl', N'Total Kjeldahl Nitrogen (Ammonia+Organic) as N')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, nitrate (NO3) as N, unfiltered', N'Nitrate (NO3) Nitrogen as N, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, nitrate (NO3) as N, filtered', N'Nitrate (NO3) Nitrogen as N, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, nitrate (NO3) nitrogen as NO3, unfiltered', N'Nitrate (NO3) Nitrogen as NO3, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, nitrate (NO3) nitrogen as NO3, filtered', N'Nitrate (NO3) Nitrogen as NO3, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, nitrite (NO2) + nitrate (NO3) nitrogen as N', N'Nitrite (NO2) + Nitrate (NO3) Nitrogen as N')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, nitrite (NO2) nitrogen as N', N'Nitrite (NO2) Nitrogen as N')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, nitrite (NO2) nitrogen as NO2', N'Nitrite (NO2) Nitrogen as NO2')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, organic as N, filtered', N'Organic Nitrogen as N, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, organic as N, unfiltered', N'Organic Nitrogen as N, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, particulate organic as N', N'Particulate Organic Nitrogen as N')
GO
print 'Processed 100 total records'
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, total as N', N'Total Nitrogen (NO3+NO2+NH4+NH3+Organic)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Oxygen, dissolved, transducer signal', N'Dissolved oxygen, raw data from sensor')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Oxygen, dissolved', N'Dissolved oxygen')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Oxygen, dissolved percent of saturation', N'Dissolved oxygen, percent saturation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'pH, filtered', N'pH, filtered')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'pH, unfiltered', N'pH, unfiltered')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Pheophytin', N'Pheophytin (Chlorophyll which has lost the central Mg ion) is a degradation product of Chlorophyll')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, inorganic as P', N'Inorganic Phosphorus as P')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, organic as P', N'Organic Phosphorus as P')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, ortophosphate as P, filtered', N'Orthophosphate Phosphorus as P, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, ortophosphate as P, unfiltered', N'Orthophosphate Phosphorus as P, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, ortophosphate as PO4, filtered', N'Orthophosphate Phosphorus as PO4, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, ortophosphate as PO4, unfiltered', N'Orthophosphate Phosphorus as PO4, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, phosphate (PO4) as P', N'Phosphate Phosphorus as P')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, phosphate (PO4) as PO4', N'Phosphate Phosphorus as PO4')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, polyphosphate as PO4', N'Polyphosphate Phosphorus as PO4')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, total as P', N'Total Phosphorus as P')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, total as PO4', N'Total Phosphorus as PO4')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Potassium', N'Potassium (K)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Precipitation', N'Precipitation such as rainfall. Should not be confused with settling.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, incoming longwave', N'Incoming Longwave Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, incoming PAR', N'Incoming Photosynthetically-Active Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Alloxanthin', N'The phytoplankton pigment Alloxanthin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Zeaxanthin', N'The phytoplankton pigment Zeaxanthin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Diatoxanthin', N'The phytoplankton pigment Diatoxanthin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Canthaxanthin', N'The phytoplankton pigment Canthaxanthin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Cryptophytes', N'The chlorophyll a concentration contributed by cryptophytes')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Dinoflagellates', N'The chlorophyll a concentration contributed by Dinoflagellates')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll a allomer', N'The phytoplankton pigment Chlorophyll a allomer')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll Fluorescence', N'Chlorophyll Fluorescence')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Colored Dissolved Organic Matter', N'The concentration of colored dissolved organic matter (humic substances)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Signal-to-noise ratio', N'Signal-to-noise ratio (often abbreviated SNR or S/N) is defined as the ratio of a signal power to the noise power corrupting the signal. The higher the ratio, the less obtrusive the background noise is.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Velocity', N'The velocity of the water flowing through a channel')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Volume', N'Volume. To quantify discharge or hydrograph volume or some other volume measurement.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Latitude', N'Latitude as a variable measurement or observation (Spatial reference to be designated in methods).  This is distinct from the latitude of a site which is a site attribute.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Longitude', N'Longitude as a variable measurement or observation (Spatial reference to be designated in methods). This is distinct from the longitude of a site which is a site attribute.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, total as P, filtered', N'Total Phosphorus as P, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Evapotranspiration, potential', N'The amount of water that could be evaporated and transpired if there was sufficient water available.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Leaf wetness', N'The effect of moisture settling on the surface of a leaf as a result of either condensation or rainfall.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Streamflow', N'The volume of water flowing past a fixed point.  Equivalent to discharge')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, ammonia (NH3) + ammonium (NH4)', N'see EPA method 350.1')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Reduction potential', N'Oxidation-reduction potential')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll a, uncorrected', N'Chlorophyll a uncorrected for pheophytin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll a, corrected', N'Chlorphyll a corrected for pheophytin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Phosphorus, total dissolved', N'Total dissolved phosphorus')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, total dissolved', N'Total dissolved nitrogen')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Hardness, carbonate', N'Carbonate hardness also known as temporary hardness as calcium carbonate')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, incoming shortwave', N'Incoming Shortwave Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, incoming UV-A', N'Incoming Ultraviolet A Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, incoming UV-B', N'Incoming Ultraviolet B Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, net', N'Net Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, net longwave', N'Net Longwave Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, net PAR', N'Net Photosynthetically-Active Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, net shortwave', N'Net Shortwave radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, outgoing longwave', N'Outgoing Longwave Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, outgoing PAR', N'Outgoing Photosynthetically-Active Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, outgoing shortwave', N'Outgoing Shortwave Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Carbon to Nitrogen molar ratio', N'C:N (molar)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Radiation, total shortwave', N'Total Shortwave Radiation')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Relative humidity', N'Relative humidity')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Salinity', N'Salinity')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Secchi depth', N'Secchi depth')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sensible Heat Flux', N'Sensible Heat Flux')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Silica, filtered', N'Silica (SiO2), filtered')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Silicate as Si', N'Silicate as Si')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Silicate as SiO2', N'Silicate as SiO2')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Silicon as Si', N'Silicon as Si')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Silicon as SiO2', N'Silicon (Si) as SiO2')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Snow depth', N'Snow depth')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sodium adsorption ratio', N'Sodium adsorption ratio')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sodium plus potassium as sodium, filtered', N'Sodium plus potassium as sodium, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sodium, fraction of cations', N'Sodium, fraction of cations')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, fixed Dissolved', N'Fixed Dissolved Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, fixed Suspended', N'Fixed Suspended Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, total', N'Total Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, total Dissolved', N'Total Dissolved Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, total Fixed', N'Total Fixed Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, total Suspended', N'Total Suspended Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, total Volatile', N'Total Volatile Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, volatile Dissolved', N'Volatile Dissolved Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Solids, volatile Suspended', N'Volatile Suspended Solids')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Vapor pressure', N'The pressure of a vapor in equilibrium with its non-vapor phases')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Specific conductance, filtered', N'Specific conductance, filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Specific conductance, unfiltered', N'Specific conductance, unfiltered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Streptococci, fecal', N'Fecal Streptococci')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sulfate as S', N'Sulfate (SO4) as S')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sulfate as SO4', N'Sulfate as SO4')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sulfate, filtered', N'Sulfate (SO4), filtered sample')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sulfur', N'Sulfur (S)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sulfur dioxide', N'Sulfur dioxide (SO2)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sulfur, Organic as S', N'Organic Sulfur as S')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sulfur, pyritic', N'Pyritic Sulfur')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sunshine duration', N'Sunshine duration')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'TDR waveform relative length', N'Time domain reflextometry, apparent length divided by probe length. Square root of dielectric')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Temperature', N'Temperature')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Temperature, transducer signal', N'Temperature, raw data from sensor')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Transpiration', N'Transpiration')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Turbidity', N'Turbidity')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Vapor pressure deficit', N'The difference between the actual water vapor pressure and the saturation of water vapor pressure at a particular temperature.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Visibility', N'Visibility')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Volumetric water content', N'Volume of liquid water relative to bulk volume. Used for example to quantify soil moisture')
GO
print 'Processed 200 total records'
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Water depth, averaged', N'Water depth averaged over a channel cross-section or water body.  Averaging method to be specified in methods.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Water depth', N'Water depth is the distance between the water surface and the bottom of the water body at a specific location specified by the site location and offset.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Water vapor density', N'Water vapor density')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Wind direction', N'Wind direction')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Wind speed', N'Wind speed')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Zinc', N'Zinc (Zn)')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Snow Water Equivalent', N'The depth of water if a snow cover is completely melted, expressed in units of depth, on a corresponding horizontal surface area.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Primary Productivity', N'Primary Productivity')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Chlorophyll c1 and c2', N'Chlorophyll c1 and c2')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Peridinin', N'The phytoplankton pigment Peridinin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'19-Hexanoyloxyfucoxanthin', N'The phytoplankton pigment 19-Hexanoyloxyfucoxanthin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'9 cis-Neoxanthin', N'The phytoplankton pigment  9 cis-Neoxanthin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Diadinoxanthin', N'The phytoplankton pigment Diadinoxanthin')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, Dissolved Inorganic', N'Dissolved inorganic nitrogen')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Nitrogen, Dissolved Organic', N'Dissolved Organic Nitrogen')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Water level', N'Water level relative to datum. The datum may be local or global such as NGVD 1929 and should be specified in the method description for associated data values.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Recorder code', N'A code used to identifier a data recorder.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Program signature', N'A unique data recorder program identifier which is useful for knowing when the source code in the data recorder has been modified.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Watchdog error count', N'A counter which counts the number of total datalogger watchdog errors')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Table overrun error count', N'A counter which counts the number of datalogger table overrun errors')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Flash memory error count', N'A counter which counts the number of  datalogger flash memory errors')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Low battery count', N'A counter of the number of times the battery voltage dropped below a minimum threshold')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Container number', N'The identifying number for a water sampler container.')
INSERT [dbo].[VariableNameCV] ([Term], [Definition]) VALUES (N'Sequence number', N'A counter of events in a sequence')
/****** Object:  Table [dbo].[ValueTypeCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValueTypeCV](
	[Term] [nvarchar](50) NOT NULL,
	[Definition] [nvarchar](500) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[ValueTypeCV] ([Term], [Definition]) VALUES (N'Unknown', N'The value type is unknown')
INSERT [dbo].[ValueTypeCV] ([Term], [Definition]) VALUES (N'Field Observation', N'Observation of a variable using a field instrument')
INSERT [dbo].[ValueTypeCV] ([Term], [Definition]) VALUES (N'Sample', N'Observation that is the result of analyzing a sample in a laboratory')
INSERT [dbo].[ValueTypeCV] ([Term], [Definition]) VALUES (N'Model Simulation Result', N'Values generated by a simulation model')
INSERT [dbo].[ValueTypeCV] ([Term], [Definition]) VALUES (N'Derived Value', N'Value that is directly derived from an observation or set of observations')
/****** Object:  StoredProcedure [dbo].[usp_updateCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_updateCV]
(
	@tablename varchar(127) = '',
	@field1 varchar(255) = '',
	@field2 varchar(255) = '',
	@field3 varchar(255) = '',
	@field4 varchar(255) = '',
	@field5 varchar(255) = '',
	@action_flag char(1) = 'A'
)

AS

BEGIN


IF @action_flag = 'A' BEGIN
	PRINT 'INSERT INTO ' + @tablename
END ELSE IF @action_flag = 'E' BEGIN
	PRINT 'UPDATE ' + @tablename + ' SET '
END ELSE IF @action_flag = 'D' BEGIN
	PRINT 'DELETE FROM ' + @tablename
END


END
GO
/****** Object:  StoredProcedure [dbo].[usp_RetrieveCV]    Script Date: 01/27/2012 09:13:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_RetrieveCV]

AS

BEGIN

CREATE TABLE #CVs
(

	table_name varchar(127),
	status char(10),
	action_flag char(10),
	date_submitted datetime,
	cv varchar(2000)

)

INSERT INTO #CVs (table_name, status, action_flag, date_submitted, cv) 
(SELECT 'temp_Units', status,
CASE action_flag 
	WHEN 'A' THEN 'Add'
	WHEN 'D' THEN 'Delete'
	WHEN 'E' THEN 'Edit'
	WHEN 'O' THEN 'Original'
END,
time_stamp, 
CONVERT(VARCHAR,UnitsID)+','+UnitsName+','+UnitsType+','+UnitsAbbreviation
FROM temp_Units)

SELECT table_name, status, action_flag, date_submitted, cv FROM #CVs

END
GO
