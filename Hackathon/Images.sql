ALTER DATABASE CURRENT
SET CHANGE_TRACKING = ON
(CHANGE_RETENTION = 2 DAYS, AUTO_CLEANUP = ON)

CREATE TABLE Images (

	[ImageId] nvarchar(450) NOT NULL PRIMARY KEY,
	[ImageURL] nvarchar(max) NOT NULL PRIMARY KEY,
	[Captions] nvarchar(max) NULL,
	[Tags] nvarchar(max) NULL
)

GO

ALTER TABLE Images
ENABLE CHANGE_TRACKING
WITH (TRACK_COLUMNS_UPDATED = ON)