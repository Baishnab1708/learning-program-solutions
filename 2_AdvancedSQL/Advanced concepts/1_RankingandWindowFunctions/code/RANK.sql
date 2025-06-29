WITH RankedByRank AS (
  SELECT
    p.ProductID,
    p.Name           AS ProductName,
    pc.Name          AS Category,
    p.ListPrice      AS Price,
    RANK() OVER (
      PARTITION BY pc.Name
      ORDER BY p.ListPrice DESC
    ) AS rnk
  FROM SalesLT.Product AS p
  JOIN SalesLT.ProductCategory AS pc
    ON p.ProductCategoryID = pc.ProductCategoryID
)
SELECT ProductID, ProductName, Category, Price
FROM RankedByRank
WHERE rnk <= 3
ORDER BY Category, rnk;
