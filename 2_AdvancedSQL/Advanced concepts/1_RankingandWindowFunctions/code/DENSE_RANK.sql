WITH RankedByDense AS (
  SELECT
    p.ProductID,
    p.Name           AS ProductName,
    pc.Name          AS Category,
    p.ListPrice      AS Price,
    DENSE_RANK() OVER (
      PARTITION BY pc.Name
      ORDER BY p.ListPrice DESC
    ) AS drnk
  FROM SalesLT.Product AS p
  JOIN SalesLT.ProductCategory AS pc
    ON p.ProductCategoryID = pc.ProductCategoryID
)
SELECT ProductID, ProductName, Category, Price
FROM RankedByDense
WHERE drnk <= 3
ORDER BY Category, drnk;
