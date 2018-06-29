﻿// parameter temporary
var _productVariable = [];
var _isStock = false;

// order of item list
var orderItem = 0;

function showProductVariable(productVariables) {
    let html = "";

    // Header Popup
    html += "<div class='row' style='max-height: 480px; overflow-x: auto;'>"
    html += "   <table class='table table-checkable table-product'>";
    html += "      <tr id='search-product-header'>";
    html += "         <th class='order-item'>";
    html += "             <input type='checkbox' id='check-all'onchange='check_all()'/>";
    html += "         </th>";
    html += "         <th class='image-item'>Ảnh</td>";
    html += "         <th class='name-item'>Sản phẩm</td>";
    html += "         <th class='sku-item'>Mã</td>";
    html += "         <th class='variable-item'>Thuộc tính</td>";
    html += "         <th class='quantity-item'>Số lượng</td>";
    html += "      </tr>";

    // Body Popup
    productVariables.forEach(function(item) {
        html += "      <tr class='search-popup' id='search-product-detail';>";
        html += "         <td class='order-item'>";
        html += "             <input class='check-popup' data-productVariableID='" + item.ProductVariableID + "' type='checkbox' onchange='check($(this))' />";
        html += "         </td>";
        html += "         <td class='image-item'><img src='" + item.ProductImage + "'></td>";
        html += "         <td class='namer-item'>" + item.ProductTitle + "</td>";
        html += "         <td class='sku-item key'>" + item.ChildSKU + "</td>";
        html += "         <td class='variable-item'>" + item.VariableValue + "</td>";
        html += "         <td class='quantity-item'>";
        html += "             <input type='text' class='form-control quantity in-quantity' "
                                  + "pattern='[0-9]{1,3}' "
                                  + "onblur='changeQuantityPopup($(this))' "
                                  + "onkeyup='pressKeyQuantityPopup($(this))' "
                                  + "onkeypress='return event.charCode >= 48 && event.charCode <= 57' "
                                  + "value='1' >";
        html += "         </td>";
        html += "      </tr>";
    });

    // Footer Popup
    html += "   </table>";
    html += "</div>";
    html += "<div class='row'>";
    html += "   <a href='javascript: ;' class='btn link-btn' style='background-color:#f87703;float:right;color:#fff;' onclick='selectProduct()'>Chọn</a>";
    html += "</div >";

    showPopup(html);
}

// select all variable product
function check_all() {
    if ($('#check-all').is(":checked")) {
        $(".check-popup").prop('checked', true);
    } else {
        $(".check-popup").prop('checked', false);
    }
}

function check(row) {
    let productCount = $(".search-popup").length;
    let productCheckNumber = $(".search-popup > .order-item > .check-popup:checked").length;

    if (productCheckNumber == productCount) {
        $("#search-product-header > .order-item > #check-all").prop('checked', true);
    }
    else {
        $("#search-product-header > .order-item > #check-all").prop('checked', false);
    }
}

function changeQuantityPopup(obj) {
    var current = obj.val();

    if (current == 0 || current == "" || current == null) {
        obj.val("1");
    }
}

function pressKeyQuantityPopup(obj) {
    $(".in-quantity").keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }
        else if (e.which == 40) {
            // press down 
            $(this).closest('tr').next().find('td:eq(' + $(this).closest('td').index() + ')').find(".in-quantity").focus().select();
        }
        else if (e.which == 38) {
            // press up
            $(this).closest('tr').prev().find('td:eq(' + $(this).closest('td').index() + ')').find(".in-quantity").focus().select();
        }
    });
}

// select a variable product
function selectProduct() {
    let productChecked = [];

    $(".search-popup > .order-item > .check-popup:checked").each(function (index, element) {
        let id = $(element).attr("data-productVariableID");
        let quantity = parseFloat($(element).parent().parent().find("input.quantity").val());

        let productTarget = _productVariable.filter(function (x) { return x.ProductVariableID == id })[0];

        // get quantity new
        productTarget.Quantity = quantity;

        productChecked.push(productTarget);
    })

    addProduct(productChecked)

    closePopup();
    $("#txtSearch").focus();
}

function addHtmlProductResult(item) {
    let customerType = $(".customer-type").val();
    let html = "";
    let SKU = "";
    let ProductVariableName = "";
    let ProductVariableValue = "";
    let ProductVariableSave = "";

    if (item.ProductStyle == 1) {
        SKU = item.ParentSKU;
    }
    else {
        SKU = item.ChildSKU;
    }

    if (item.VariableValue != null && !isBlank(item.VariableValue)) {
        item.VariableValue.split(/:\s|<br\/>/).forEach(function (item, index) {
            if (index % 2) {
                ProductVariableValue += item + "|";
            }
            else {
                if (!isBlank(item)) {
                    ProductVariableName += item + "|";
                }
            }
        });
    }

    ProductVariableSave = item.VariableValue.replace(/<br\/>/g, "|");

    // for page them-moi-don-hang
    if (_isStock) {
        orderItem++;
    }

    if (typeof updateTemplateStock === "function") {
        // update stock which removed
        updateTemplateStock(item);
    }

    html += "<tr class='product-result' ";

    if (typeof searchRemovedList === "function") {
        let data_orderdetail = searchRemovedList(SKU);

        html += "          " + data_orderdetail + " ";
    }

    html += "          data-giabansi='" + item.RegularPrice + "' "
                    + "data-giabanle='" + item.RetailPrice + "' "
                    + "data-quantityinstock='" + item.QuantityCurrent + "' "
                    + "data-productimageorigin='" + item.ProductImage + "' "
                    + "data-productvariable='" + item.VariableValue + "' "
                    + "data-productname='" + item.ProductTitle + "' "
                    + "data-sku='" + SKU + "' "
                    + "data-producttype='" + item.ProductStyle + "' "
                    + "data-productid='" + item.ProductID + "' "
                    + "data-productvariableid='" + item.ProductVariableID + "' "
                    + "data-productvariablename='" + ProductVariableName + "' "
                    + "data-productvariablevalue ='" + ProductVariableValue + "' "
                    + "data-productvariablesave ='" + ProductVariableSave + "'>";

    // for page them-moi-don-hang
    if (_isStock) {
        html += "   <td class='order-item'>" + orderItem + "</td>";
    }

    html += "   <td class='image-item'><img src='" + item.ProductImage + "'></td>";
    html += "   <td class='name-item'>" + item.ProductTitle + "</td>";
    html += "   <td class='sku-item'>" + SKU + "</td>";
    html += "   <td class='variable-item'>" + item.VariableValue + "</td>";

    if (customerType == 1) {
        if (item.RetailPrice > 0) {
            html += "   <td class='price-item gia-san-pham' data-price='" + item.RetailPrice + "'>" + formatThousands(item.stringRetailPrice, ',') + "</td>";
        }
        else {
            html += "   <td class='price-item gia-san-pham' data-price='" + item.RegularPrice + "'>" + formatThousands(item.RegularPrice, ',') + "</td>";
        }
    } else {
        html += "   <td class='price-item gia-san-pham' data-price='" + item.RegularPrice + "'>" + formatThousands(item.RegularPrice, ',') + "</td>";
    }

    // for page them-moi-don-hang
    if (_isStock) {
        html += "<td class='quantity-item'>" + formatThousands(item.QuantityCurrent, ',') + "</td>";
    }

    html += "   <td class='quantity-item'> "
    html += "       <input type='text' class='form-control in-quantity' "
                        + "pattern='[0-9]{1,3}' "
                        + "onblur='checkQuantiy($(this))' "
                        + "onkeyup='pressKeyQuantity($(this))' "
                        + "onkeypress='return event.charCode >= 48 && event.charCode <= 57' ";

    // if product exists in table, increase quantityty
    if (item.Quantity !== undefined) {
        html += "              value='" + formatThousands(item.Quantity, ',') + "' />";
    }
    else {
        html += "              value='1' />";
    }
    html += "   </td>";
    html += "   <td class='total-item totalprice-view'>" + formatThousands(item.RegularPrice, ',') + "</td>";
    html += "   <td class='trash-item'><a href='javascript:;' class='link-btn' onclick='deleteRow($(this))'><i class='fa fa-trash'></i></a></td>";
    html += "</tr>";

    $(".content-product").prepend(html);

    if (typeof removeProductExisted === "function") {
        removeProductExisted(item);
    }
}

// reindex item order
function reIndex() {
    var item = $(".order-item");
    for (var i = 0; i < item.length; i++) {
        $(".order-item:eq(" + i + ")").html(i + 1);
    }
}

// change quantity of product
function checkQuantiy(obj) {
    var current = obj.val();

    if (current == 0 || current == "" || current == null) {
        obj.val("1");
    }

    getAllPrice();
}

function pressKeyQuantity(obj) {
    $(".in-quantity").keyup(function (e) {
        if (/\D/g.test(this.value)) {
            // Filter non-digits from input value.
            this.value = this.value.replace(/\D/g, '');
        }
        else if (e.which == 40) {
            // press down 
            $(this).closest('tr').next().find('td:eq(' + $(this).closest('td').index() + ')').find(".in-quantity").focus().select();
        }
        else if (e.which == 38) {
            // press up
            $(this).closest('tr').prev().find('td:eq(' + $(this).closest('td').index() + ')').find(".in-quantity").focus().select();
        }
    });
}

// remove product form list
function deleteRow(obj) {
    var c = confirm('Bạn muốn xóa sản phẩm này?');
    if (c) {
        let row = obj.parent().parent();

        if (row.attr("data-orderdetailid") > 0) {
            let id = 0;
            let sku = "";
            let productID = 0;
            let quantity = 0;

            id = row.attr("data-orderdetailid");
            sku = row.attr("data-sku");

            if (row.attr("data-producttype") == 1) {
                productID = row.attr("data-productid");
            }
            else {
                productID = row.attr("data-productvariableid");
            }
            
            quantity = row.find(".in-quantity").val();

            listOrderDetail.push(
                new OrderDetailModel(
                    ID = id,
                    SKU = sku,
                    ProductID = productID,
                    Quantity = quantity)
                );
        }

        row.remove();
        getAllPrice();
        $("#txtSearch").focus();
    }
}

// Check product exists. Then add table or increase product old
function addProduct(products) {

    products.forEach(function (item) {
        let sku = item.SKU;
        let check = false;

        let target = $(".product-result[data-productID='" + item.ProductID + "'][data-productVariableID='" + item.ProductVariableID + "']");

        // Check SKU exists in table.
        if (target.length > 0) {
            let quantityinstock = parseFloat(target.attr("data-quantityinstock"));
            let quantityCurrent = parseFloat(target.find(".in-quantity").val());
            let newquantity = quantityCurrent;

            if (item.Quantity === undefined) {// case search match SKU
                newquantity = newquantity + 1;
            }
            else { // case choose product variable popup
                newquantity = newquantity + item.Quantity;
            }

            target.find(".in-quantity").val(newquantity);

            let price = parseFloat(newquantity) * parseFloat(item.Giabansi);
            target.find(".totalprice-view").html(formatThousands(price, ','));
        }
        else {
            addHtmlProductResult(item)
        }
    });

    getAllPrice();
    $("#txtSearch").val("");
}

// search product by SKU
function searchProductMaster(textsearch, isStock) {
    _productVariable = [];
    _isStock = isStock;

    if (!isBlank(textsearch)) {
        $.ajax({
            type: "POST",
            url: "ServiceCommon.asmx/GetProduct",
            data: JSON.stringify({ SKU: textsearch, isStock: _isStock }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                let data = JSON.parse(msg.d);

                if (data != null && data.length > 0) {
                    if (data.length > 1) {
                        // init value array product variable
                        _productVariable = data;

                        // show popup which choose product
                        showProductVariable(_productVariable);
                    }
                    else {
                        addProduct(data);
                    }
                }
                else {
                    $("#txtSearch").val(textsearch).select();
                    swal("Thông báo", "Không tìm thấy sản phẩm", "error");
                }
            },
            error: function (xmlhttprequest, textstatus, errorthrow) {
                alert('lỗi');
                $("#txtSearch").val(textsearch).select();
            }
        });
    } else {
        $("#txtSearch").focus();
        swal("Thông báo", "Hãy nhập mã sản phẩm", "error");
    }
}
