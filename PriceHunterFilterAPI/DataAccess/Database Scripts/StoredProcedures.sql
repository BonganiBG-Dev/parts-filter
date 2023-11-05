
CREATE PROCEDURE UpsertProduct
(
	@ID varchar(255),
	@Name varchar(255),
	@Price decimal,
	@Image varchar(255),
	@Site varchar(255),
	@Category varchar(255),
	@Link varchar(255)

)
AS
BEGIN 
	IF NOT EXISTS (SELECT 1 FROM Product WHERE Id = @ID)
	BEGIN
	 INSERT INTO Product VALUES (@ID, @Site, @Category, 'nan', @Name, @Price, @Image, @Link);
	 INSERT INTO PriceHistory(ProductId, DateUpdated, Price) VALUES (@ID, GETDATE(), @Price);
	END
	ELSE 
	BEGIN
		UPDATE Product 
		SET Price = @Price
		WHERE Id = @ID
	END
END

CREATE PROCEDURE UpdatePriceHistory
(
	@NewPrice decimal,
	@ProductID varchar(60)	
)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM Product WHERE Id = @ProductID AND Price = @NewPrice)
	BEGIN
		INSERT INTO PriceHistory(ProductId, DateUpdated, Price) VALUES (@ProductID, GETDATE(), @NewPrice);
	END
END

SELECT * FROM Product

SELECT * from PriceHistory
