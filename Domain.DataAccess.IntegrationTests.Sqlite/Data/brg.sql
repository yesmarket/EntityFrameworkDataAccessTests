DROP TABLE IF EXISTS "brg_rule";
CREATE TABLE [brg_rule](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [text] NULL,
	[shortName] [varchar](20) NULL,
	[propertiesPage] [bit] NULL
);
DROP TABLE IF EXISTS "brg_rule_properties";
CREATE TABLE [brg_rule_properties](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brg_rule_id] [int] NULL,
	[property_name] [varchar](50) NULL,
	[property_value] [varchar](50) NULL CONSTRAINT [DF_brg_rule_properties_property_value]  DEFAULT ((0)),
	[datetime] [datetime] NULL CONSTRAINT [DF_brg_rule_properties_datetime]  DEFAULT (getdate()),
	[Description] [text] NULL
);
DROP TABLE IF EXISTS "vbrg_rule_properties";
CREATE TABLE [vbrg_rule_properties](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brg_rule_id] [int] NULL,
	[property_name] [varchar](50) NULL,
	[property_value] [varchar](50) NULL CONSTRAINT [DF_brg_rule_properties_property_value]  DEFAULT ((0)),
	[datetime] [datetime] NULL CONSTRAINT [DF_brg_rule_properties_datetime]  DEFAULT (getdate()),
	[Description] [text] NULL,
	[shortName] [varchar](20) NULL
);
