WITH RankedByRowNum AS (
  SELECT
    p.ProductID,
    p.Name           AS ProductName,
    pc.Name          AS Category,
    p.ListPrice      AS Price,
    ROW_NUMBER() OVER (
      PARTITION BY pc.Name
      ORDER BY p.ListPrice DESC
    ) AS rn
  FROM SalesLT.Product AS p
  JOIN SalesLT.ProductCategory AS pc
    ON p.ProductCategoryID = pc.ProductCategoryID
)
SELECT ProductID, ProductName, Category, Price
FROM RankedByRowNum
WHERE rn <= 3
ORDER BY Category, rn;
