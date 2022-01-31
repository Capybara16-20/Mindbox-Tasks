SELECT Product.Name AS 'Product', coalesce(Category.Name, 'No category') AS 'Category'
FROM (Product LEFT JOIN Product_Categories ON Product.ID = Product_Categories.Product)
	LEFT JOIN Category ON Category.ID = Product_Categories.Category
ORDER BY Product.Name, Category.Name
