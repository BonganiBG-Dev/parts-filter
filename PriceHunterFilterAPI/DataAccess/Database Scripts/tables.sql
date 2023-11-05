CREATE TABLE Product
(
	Id varchar(60) PRIMARY KEY,
	SiteId varchar(60) NOT NULL,
	CategoryId varchar(60) NOT NULL,
	SeriesId varchar(60) NOT NULL,
	Name varchar(128) NOT NULL,
	Price decimal NOT NULL,
	Image varchar(255),
	Link varchar(255)
)

CREATE TABLE PriceHistory
(
	Id int IDENTITY PRIMARY KEY,
	ProductId varchar(60) FOREIGN KEY REFERENCES Product(Id),
	DateUpdated datetime NOT NULL,
	Price decimal NOT NULL
)