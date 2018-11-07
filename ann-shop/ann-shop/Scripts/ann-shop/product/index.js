// Show image other
$(document).ready(function () {
    if ($(".product-thumb-vertical").length > 0 && $(window).width() >= 1200) {
        $(".product-thumb-vertical").mThumbnailScroller({
            axis: "y",
            type: "click-thumb",
            theme: "buttons-out",
            type: "hover-precise",
            contentTouchScroll: true
        });
        $('.product-thumb-vertical').css('height', $('.product-image-feature').height());
        $('#sliderproduct').show();
    }
    if ($(".product-thumb-vertical").length > 0 && $(window).width() < 1200) {
        $(".product-thumb-vertical").mThumbnailScroller({
            axis: "x",
            theme: "buttons-out",
            contentTouchScroll: true
        });
        $('#sliderproduct').show();
    }
});

var product = { "available": true, "compare_at_price_max": 0.0, "compare_at_price_min": 0.0, "compare_at_price_varies": false, "compare_at_price": 0.0, "content": null, "description": "<p>Bikini Beach sở hữu kiểu dáng thời trang, thiết kế phối dây quyến rũ, phối họa tiết tropical đẹp mắt, mang đến vẻ ngoài nóng bỏng và năng động.</p><ul><li>Chất liệu vải thun</li><li>Áo thiết kế thể thao phối dây quyến rũ</li><li>Quần lưng thấp phối 3 dây gợi cảm</li><li>Họa tiết tropical năng động</li><li>Sản xuất tại Việt Nam</li><li>Size mẫu mặc: S. Số đo mẫu:&nbsp;80 - 58 - 88 - 171 (cm)</li></ul><table class=\"table table-bordered mce-item-table\" id=\"tblGeneralAttribute\" style=\"box-sizing: border-box; border-collapse: collapse; border-spacing: 0px; background-color: #ffffff; width: 100%; min-width: 500px; max-width: 100%; margin-bottom: 20px; border: 1px solid #eeeeee; color: #333333; font-family: Roboto, sans-serif; font-size: 13px;\" data-mce-style=\"box-sizing: border-box; border-collapse: collapse; border-spacing: 0px; background-color: #ffffff; width: 100%; min-width: 500px; max-width: 100%; margin-bottom: 20px; border: 1px solid #eeeeee; color: #333333; font-family: Roboto, sans-serif; font-size: 13px;\"><tbody style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><tr class=\"row-info\" style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\"><span style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\" data-mce-style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\">Số đo người mẫu</span></td><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\">80 - 58 - 88 - 171 (cm)</td></tr><tr class=\"row-info\" style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\"><span style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\" data-mce-style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\">Size người mẫu mặc</span></td><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\">S</td></tr><tr class=\"row-info\" style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\"><span style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\" data-mce-style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\">Xuất xứ</span></td><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\">Việt Nam</td></tr><tr class=\"row-info\" style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\"><span style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\" data-mce-style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\">Chất liệu vải</span></td><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\">Vải thun</td></tr></tbody></table><p><strong>Hướng dẫn bảo quản</strong></p><ul><li>Giặt tay</li><li>Không tẩy</li><li>Phơi trong bóng râm</li><li>Ủi ở nhiệt độ thấp</li></ul><p><strong>Thông tin thương hiệu</strong></p><p>Bikini Beach là thương hiệu thời trang đồ lót, sản phẩm mặc nhà đang phát triển mạnh tại thị trường Việt Nam thuộc quyền sở hữu của công ty Nữ Hoàng Thời Trang. Wannabe đang sử dụng nguyên liệu nhập khẩu từ các nước uy tín như Nhật, Đài Loan, Thái Lan,… Sản phẩm được gia công trên dây chuyền sản xuất tiên tiến và đội ngũ công nhân lành nghề. Chúng tôi tự hào tạo ra những sản phẩm uy tín, chất lượng và phù hợp với hình thể người phụ nữ Việt Nam.</p><p><br></p><p><br></p><p><br></p>", "featured_image": "/images/0530_la_07.jpg", "handle": "tankini-top-swimskirt-juni", "id": 1003793498, "images": ["/images/0530_la_07.jpg", "/images/0530_la_12.jpg", "/images/0530_la_76.jpg", "/images/0530_la_02.jpg", "/images/0530_rg1_sp1_06.jpg", "/images/0530_la_33.jpg", "/images/0530_la_49.jpg", "/images/0530_la_25.jpg"], "options": ["Kích thước", "Màu sắc"], "price": 139000000.0, "price_max": 139000000.0, "price_min": 139000000.0, "price_varies": false, "tags": ["Bikini Juni"], "template_suffix": null, "title": "Tankini top  swimskirt Juni", "type": "Crochet Bikini", "url": "/products/tankini-top-swimskirt-juni", "pagetitle": "Tankini top  swimskirt Juni", "metadescription": "Bikini Beach sở hữu kiểu dáng thời trang, thiết kế phối dây quyến rũ, phối họa tiết tropical đẹp mắt, mang đến vẻ ngoài nóng bỏng và năng động.\n\nChất liệu vải t", "variants": [{ "id": 1009627901, "barcode": null, "available": true, "price": 139000000.0, "sku": "SWIM1", "option1": "M", "option2": "Xanh", "option3": "", "options": ["M", "Xanh"], "inventory_quantity": 1, "old_inventory_quantity": 1, "title": "M / Xanh", "weight": 0.0, "compare_at_price": 0.0, "inventory_management": null, "inventory_policy": "deny", "selected": false, "url": null, "featured_image": null }], "vendor": "Juni", "published_at": "2016-12-11T10:21:28.04Z", "created_at": "2016-12-11T10:21:28.04Z", "not_allow_promotion": false };
var selectCallback = function (variant, selector) {
    if (variant && variant.available) {
        $('.product-image-feature').hide();
        $('.lazy-product-featured').show();
        $(".product-thumb").children('a.zoomGalleryActive').removeClass('zoomGalleryActive');
        if (variant != null && variant.featured_image != null) {
            $(".product-thumb a[data-image='" + Haravan.resizeImage(variant.featured_image.src, '1024x1024') + "']").click();
        }
        $('.lazy-product-featured').hide();
        $('.product-image-feature').show();
        if (variant.sku != null) {
            jQuery('#pro_sku').html('SKU: ' + variant.sku);
        }
        jQuery('.addtocart').removeAttr('disabled');
        jQuery('.addnow').removeAttr('disabled');
        if (variant.price < variant.compare_at_price) {
            jQuery('#price-preview').html("<span>" + Haravan.formatMoney(variant.price, "{{amount}}₫") + "</span><del>" + Haravan.formatMoney(variant.compare_at_price, "{{amount}}₫") + "</del>");
            var pro_sold = variant.price;
            var pro_comp = variant.compare_at_price / 100;
            var sale = 100 - (pro_sold / pro_comp);
            var kq_sale = Math.round(sale);
            jQuery('#surround .product-sale span').html("<label class='sale-lb'>Sale</label> " + kq_sale + '%');
        } else {
            if (variant.price == 0) {
                jQuery('#price-preview').html("<span style='font-size:16px;'>Liên hệ</span>");
            } else {
                jQuery('#price-preview').html("<span>" + Haravan.formatMoney(variant.price, "{{amount}}₫" + "</span>"));
            }
        }
    } else {
        jQuery('.addtocart').attr('disabled', 'disabled');
        jQuery('.addnow').attr('disabled', 'disabled');
        var message = variant ? "Hết hàng" : "Không có hàng";
        jQuery('#price-preview').html('<span>' + message + '</span>');
        $('.lazy-product-featured').hide();
        $('.product-image-feature').show();
    }
};
jQuery(document).ready(function ($) {

    new Haravan.OptionSelectors("product-select", { product: { "available": true, "compare_at_price_max": 0.0, "compare_at_price_min": 0.0, "compare_at_price_varies": false, "compare_at_price": 0.0, "content": null, "description": "<p>Bikini Beach sở hữu kiểu dáng thời trang, thiết kế phối dây quyến rũ, phối họa tiết tropical đẹp mắt, mang đến vẻ ngoài nóng bỏng và năng động.</p><ul><li>Chất liệu vải thun</li><li>Áo thiết kế thể thao phối dây quyến rũ</li><li>Quần lưng thấp phối 3 dây gợi cảm</li><li>Họa tiết tropical năng động</li><li>Sản xuất tại Việt Nam</li><li>Size mẫu mặc: S. Số đo mẫu:&nbsp;80 - 58 - 88 - 171 (cm)</li></ul><table class=\"table table-bordered mce-item-table\" id=\"tblGeneralAttribute\" style=\"box-sizing: border-box; border-collapse: collapse; border-spacing: 0px; background-color: #ffffff; width: 100%; min-width: 500px; max-width: 100%; margin-bottom: 20px; border: 1px solid #eeeeee; color: #333333; font-family: Roboto, sans-serif; font-size: 13px;\" data-mce-style=\"box-sizing: border-box; border-collapse: collapse; border-spacing: 0px; background-color: #ffffff; width: 100%; min-width: 500px; max-width: 100%; margin-bottom: 20px; border: 1px solid #eeeeee; color: #333333; font-family: Roboto, sans-serif; font-size: 13px;\"><tbody style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><tr class=\"row-info\" style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\"><span style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\" data-mce-style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\">Số đo người mẫu</span></td><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\">80 - 58 - 88 - 171 (cm)</td></tr><tr class=\"row-info\" style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\"><span style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\" data-mce-style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\">Size người mẫu mặc</span></td><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\">S</td></tr><tr class=\"row-info\" style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\"><span style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\" data-mce-style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\">Xuất xứ</span></td><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\">Việt Nam</td></tr><tr class=\"row-info\" style=\"box-sizing: border-box;\" data-mce-style=\"box-sizing: border-box;\"><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 31.348%; background-color: #f7f7f7 !important;\"><span style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\" data-mce-style=\"box-sizing: border-box; font-family: Roboto-Medium, sans-serif;\">Chất liệu vải</span></td><td style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\" data-mce-style=\"box-sizing: border-box; padding: 8px; line-height: 20px; vertical-align: top; border: 1px solid #eeeeee; width: 68.4953%;\">Vải thun</td></tr></tbody></table><p><strong>Hướng dẫn bảo quản</strong></p><ul><li>Giặt tay</li><li>Không tẩy</li><li>Phơi trong bóng râm</li><li>Ủi ở nhiệt độ thấp</li></ul><p><strong>Thông tin thương hiệu</strong></p><p>Bikini Beach là thương hiệu thời trang đồ lót, sản phẩm mặc nhà đang phát triển mạnh tại thị trường Việt Nam thuộc quyền sở hữu của công ty Nữ Hoàng Thời Trang. Wannabe đang sử dụng nguyên liệu nhập khẩu từ các nước uy tín như Nhật, Đài Loan, Thái Lan,… Sản phẩm được gia công trên dây chuyền sản xuất tiên tiến và đội ngũ công nhân lành nghề. Chúng tôi tự hào tạo ra những sản phẩm uy tín, chất lượng và phù hợp với hình thể người phụ nữ Việt Nam.</p><p><br></p><p><br></p><p><br></p>", "featured_image": "/images/0530_la_07.jpg", "handle": "tankini-top-swimskirt-juni", "id": 1003793498, "images": ["/images/0530_la_07.jpg", "/images/0530_la_12.jpg", "/images/0530_la_76.jpg", "/images/0530_la_02.jpg", "/images/0530_rg1_sp1_06.jpg", "/images/0530_la_33.jpg", "/images/0530_la_49.jpg", "/images/0530_la_25.jpg"], "options": ["Kích thước", "Màu sắc"], "price": 139000000.0, "price_max": 139000000.0, "price_min": 139000000.0, "price_varies": false, "tags": ["Bikini Juni"], "template_suffix": null, "title": "Tankini top  swimskirt Juni", "type": "Crochet Bikini", "url": "/products/tankini-top-swimskirt-juni", "pagetitle": "Tankini top  swimskirt Juni", "metadescription": "Bikini Beach sở hữu kiểu dáng thời trang, thiết kế phối dây quyến rũ, phối họa tiết tropical đẹp mắt, mang đến vẻ ngoài nóng bỏng và năng động.\n\nChất liệu vải t", "variants": [{ "id": 1009627901, "barcode": null, "available": true, "price": 139000000.0, "sku": "SWIM1", "option1": "M", "option2": "Xanh", "option3": "", "options": ["M", "Xanh"], "inventory_quantity": 1, "old_inventory_quantity": 1, "title": "M / Xanh", "weight": 0.0, "compare_at_price": 0.0, "inventory_management": null, "inventory_policy": "deny", "selected": false, "url": null, "featured_image": null }], "vendor": "Juni", "published_at": "2016-12-11T10:21:28.04Z", "created_at": "2016-12-11T10:21:28.04Z", "not_allow_promotion": false }, onVariantSelected: selectCallback });
    // Add label if only one product option and it isn't 'Title'.

    // Auto-select first available variant on page load.


    $('.single-option-selector:eq(0)').val("M").trigger('change');

    $('.single-option-selector:eq(1)').val("Xanh").trigger('change');


    $('.selector-wrapper select').each(function () {
        $(this).wrap('<span class="custom-dropdown custom-dropdown-white"></span>');
        $(this).addClass("custom-dropdown-select custom-dropdown-white-select");
    });

    // Xữ lý render variant
    if ($('#add-item-form select[data-option=option1] option').length > 0) {
        var checked = $('select[data-option=option1]').val();
        $('select[data-option=option1] option').each(function () {
            var arr_opt = '';
            var opt_select_1 = $(this).val();
            $.each(product.variants, function (i, v) {
                var opt1 = v.option1;
                if (opt_select_1 == opt1 && v.available) {
                    arr_opt = arr_opt + ' ' + slug(v.option1);
                }
            });
            if (arr_opt == '') {
                arr_opt = 'hidden';
            }
            if ($(this).val() == checked) {
                $('.data-opt1').append("<li class='" + arr_opt + "'><label><input checked='checked' type='radio' value='" + $(this).val() + "' name='option1'><span>" + $(this).val() + "</span></label></li>");
            } else {
                $('.data-opt1').append("<li class='" + arr_opt + "'><label><input type='radio' value='" + $(this).val() + "' name='option1'><span>" + $(this).val() + "</span></label></li>");
            }
        });
    }
    if ($('#add-item-form select[data-option=option2] option').length > 0) {
        var checked = $('select[data-option=option2]').val();
        $('select[data-option=option2] option').each(function () {
            var arr_opt = '';
            var opt_select_2 = $(this).val();
            $.each(product.variants, function (i, v) {
                var opt2 = v.option2;
                if (opt_select_2 == opt2 && v.available) {
                    arr_opt = arr_opt + ' ' + slug(v.option1);
                }
            });
            if ($(this).val() == checked) {
                $('.data-opt2').append("<li class='" + arr_opt + "'><label><input checked='checked' type='radio' value='" + $(this).val() + "' name='option2'><span>" + $(this).val() + "</span></label></li>");
            } else {
                $('.data-opt2').append("<li class='" + arr_opt + "'><label><input type='radio' value='" + $(this).val() + "' name='option2'><span>" + $(this).val() + "</span></label></li>");
            }
        });
    }
    if ($('#add-item-form select[data-option=option3] option').length > 0) {
        var checked = $('select[data-option=option3]').val();
        $('select[data-option=option3] option').each(function () {
            var arr_opt = '';
            var opt_select_3 = $(this).val();
            $.each(product.variants, function (i, v) {
                var opt3 = v.option3;
                if (opt_select_3 == opt3 && v.available) {
                    arr_opt = arr_opt + ' ' + slug(v.option1 + '-' + v.option2);
                }
            });
            if ($(this).val() == checked) {
                $('.data-opt3').append("<li class='" + arr_opt + "'><label><input checked='checked' type='radio' value='" + $(this).val() + "' name='option3'><span>" + $(this).val() + "</span></label></li>");
            } else {
                $('.data-opt3').append("<li class='" + arr_opt + "'><label><input type='radio' value='" + $(this).val() + "' name='option3'><span>" + $(this).val() + "</span></label></li>");
            }
        });
    }
    jQuery(document).on('click', '#add-item-form ul.data-opt1 li', function () {
        var v_opt1 = jQuery(this).find('span').html();
        jQuery('#add-item-form select[data-option=option1]').val(v_opt1).change();
        if (jQuery('#add-item-form ul.data-opt2 li:visible').length > 0) {
            jQuery('#add-item-form ul.data-opt2 li').hide();
            jQuery('#add-item-form ul.data-opt2 li.' + slug(v_opt1)).show();
            jQuery('#add-item-form ul.data-opt2 li:visible label')[0].click();
        }
    });
    jQuery(document).on('click', '#add-item-form ul.data-opt2 li', function () {
        var v_opt1 = slug(jQuery('#add-item-form select[data-option=option1]').val());
        var v_opt2 = jQuery(this).find('span').html();
        var both_v_opt = v_opt1 + '-' + slug(v_opt2);
        jQuery('#add-item-form select[data-option=option2]').val(v_opt2).change();
        if (jQuery('#add-item-form ul.data-opt3 li:visible').length > 0) {
            jQuery('#add-item-form ul.data-opt3 li').hide();
            jQuery('#add-item-form ul.data-opt3 li.' + both_v_opt).show();
            jQuery('#add-item-form ul.data-opt3 li:visible label')[0].click();
        }
    });
    jQuery(document).on('click', '#add-item-form ul.data-opt3 li', function () {
        var v_opt3 = $(this).find('span').html();
        jQuery('#add-item-form select[data-option=option3]').val(v_opt3).change();
    });
    if (jQuery('#add-item-form ul.data-opt1 li:visible label').length > 0) {
        jQuery('#add-item-form ul.data-opt1 li:visible label').first().click();
    } else {
        $('#add-item-form select').change();
    }
    $('.addnow').click(function (e) {
        e.preventDefault();
        $.ajax({
            type: 'POST',
            async: false,
            url: '/cart/add.js',
            async: false,
            data: $('form#add-item-form').serialize(),
            success: function (line) {
                window.location = "/checkout";
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Sản phẩm bạn vừa mua đã hết');
            }
        });
    });
    $('.addtocart-modal').click(function (e) {
        e.preventDefault();
        $(this).addClass('clicked_buy');
        add_item_show_modalCart($('#product-select').val());
    })
});
setTimeout(function () {
    if ($(".product-thumb-vertical").length > 0 && $(window).width() >= 1200) {
        jQuery(".product-image-feature").elevateZoom({
            gallery: 'sliderproduct',
            scrollZoom: true
        });
    }
    if ($(".product-thumb-vertical").length > 0 && $(window).width() < 1200) {
        jQuery(".product-image-feature").elevateZoom({
            gallery: 'sliderproduct',
            zoomEnabled: false
        });
    }
}, 500);