CREATE INDEX [ID_StockManager] ON tbl_StockManager
(
    [ID]
    , [AgentID]
    , [ProductID]
    , [ProductVariableID]
)
GO

CREATE INDEX [ID_SKU] ON tbl_StockManager(SKU)
GO