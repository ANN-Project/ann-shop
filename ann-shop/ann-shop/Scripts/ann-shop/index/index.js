$(document).ready(function () {
    // Handle for device mobile
    $('nav#menu-mobile').mmenu();

    flagg = true;

    if (flagg) {
        $('.click-menu-mobile a').click(function () {
            $('#menu-mobile').removeClass('hidden');
            flagg = false;
        })
    }

    // Handle for desktop
    HDeskNav();
});

function HDeskNav() {
    var $nav = $('#main-menu'),
        $allLinks = $nav.find('a'),
        $topLevel = $nav.children('li').find('a'),
        $parents = $nav.find('.site-nav-hassub'),
        $subMenuLinks = $nav.find('.site-nav-sub').find('a'),
        activeClass = 'nav-hover',
        focusClass = 'nav-focus';

    $parents.on('mouseenter touchstart', function (evt) {
        var $el = $(this);

        if (!$el.hasClass(activeClass)) {
            evt.preventDefault();
        }

        showDropdown($el);
    });

    $parents.on('mouseleave', function () {
        hideDropdown($(this));
    });

    $subMenuLinks.on('touchstart', function (evt) {
        evt.stopImmediatePropagation();
    });

    $allLinks.focus(function () {
        handleFocus($(this));
    });

    $allLinks.blur(function () {
        removeFocus($topLevel);
    });

    function handleFocus($el) {
        var $subMenu = $el.next('ul'),
                hasSubMenu = $subMenu.hasClass('sub-nav') ? true : false,
                isSubItem = $('.site-nav-sub').has($el).length,
                $newFocus = null;

        if (!isSubItem) {
            removeFocus($topLevel);
            addFocus($el);
        } else {
            $newFocus = $el.closest('.site-nav-hassub').find('a');
            addFocus($newFocus);
        }
    }

    function showDropdown($el) {
        $el.addClass(activeClass);

        setTimeout(function () {
            $('body').on('touchstart', function () {
                hideDropdown($el);
            });
        }, 250);
    }

    function hideDropdown($el) {
        $el.removeClass(activeClass);
        $('body').off('touchstart');
    }

    function addFocus($el) {
        $el.addClass(focusClass);
    }

    function removeFocus($el) {
        $el.removeClass(focusClass);
    }
}

/* QUICK VIEW JS */
jQuery(document).ready(function () {
    var callBack = function (variant, selector) {
        if (variant) {
            item = $('.wrapper-quickview');
            if (variant != null && variant.featured_image != null) {
                item.find(".slide-quickview a[data-image='" + Haravan.resizeImage(variant.featured_image.src, 'large') + "']").click();
            }
            item.find('.quickview-price').find('span').html(Haravan.formatMoney(variant.price, "{{amount}}"));
            if (variant.compare_at_price > 0)
                item.find('.quickview-price').find('del').html(Haravan.formatMoney(variant.compare_at_price, "{{amount}}"));
            else
                item.find('.quickview-price').find('del').html('');
            if (variant.available) {
                item.find('.btn-addcart').css('display', 'block');
                item.find('.btn-soldout').css('display', 'none');
            }
            else {
                item.find('.btn-addcart').css('display', 'none');
                item.find('.btn-soldout').css('display', 'block');
            }
        }
        else {
            item.find('.btn-addcart').css('display', 'none');
            item.find('.btn-soldout').css('display', 'block');
        }
    }
    var quickview_html_variants = $('.quickview-variants').html();
    var quickview_image_zoom = $('.quickview-image').html();
    var quickViewProduct = function (purl) {
        if ($(window).width() < 680) {
            window.location = purl;
            return false;
        }
        item = $('.wrapper-quickview');
        $.ajax({
            url: purl + '.js',
            async: false,
            success: function (product) {
                $.each(product.options, function (i, v) {
                    product.options[i] = v.name;
                })
                item.find('.quickview-title').attr('title', product.title).attr('href', product.url).find('h2').html(product.title);
                item.find('.quickview-variants').html(quickview_html_variants);
                $('.quickview-image').html(quickview_image_zoom);
                $.each(product.variants, function (i, v) {
                    item.find('#quickview-select').append("<option value='" + v.id + "'>" + v.title + ' - ' + v.price + "</option>");
                })
                if (product.variants.length == 1 && product.variants[0].title.indexOf('Default') != -1)
                    $('#quickview-select').hide();
                else
                    $('#quickview-select').show();
                if (product.variants.length == 1 && product.variants[0].title.indexOf('Default') != -1) {
                    callBack(product.variants[0], null);
                }
                else {
                    new Haravan.OptionSelectors("quickview-select", { product: product, onVariantSelected: callBack });
                    if (product.options.length == 1 && product.options[0].indexOf('Ti�u d?') == -1)
                        item.find('.selector-wrapper:eq(0):not(.opt1-quickview):not(.opt2-quickview):not(.opt3-quickview)').prepend('<label>' + product.options[0] + '</label>');
                    $('.quickview-variants select:not(#quickview-select)').each(function () {
                        $(this).wrap('<span class="custom-dropdown"></span>');
                        $(this).addClass("custom-dropdown-select");
                    });
                    callBack(product.variants[0], null);
                }
                if (product.images.length == 0) {
                    item.find('.quickview-image').find('img').attr('alt', product.title).attr('src', '//hstatic.net/0/0/global/noDefaultImage6_large.gif');
                }
                else {
                    $('.quickview-slider').remove();
                    $('#quickview-sliderproduct').append("<div class='quickview-slider owl-carousel slide-quickview'>");
                    $.each(product.images, function (i, v) {
                        elem = $('<div class="item">').append('<a href="javascript:void(0);" data-image=""><img /></a>');
                        elem.find('a').attr('data-image', Haravan.resizeImage(v, 'large'));
                        elem.find('img').attr('src', Haravan.resizeImage(v, 'small'));
                        item.find('.quickview-slider').append(elem);
                    });
                    item.find('.quickview-image img').attr('alt', product.title).attr('src', Haravan.resizeImage(product.featured_image, 'large'));

                    $('.quickview-slider img').imagesLoaded(function () {
                        setTimeout(function () {
                            $('.quickview-slider').owlCarousel({
                                items: 4,
                                nav: true,
                                dots: false,
                                margin: 5
                            });
                            $('.quickview-slider.owl-carousel').find('.owl-next').html("<svg class='svg-next-icon svg-next-icon-size-16' style='fill:#666'><use xlink:href='#icon-right-owlCarousel'></use></svg>");
                            $('.quickview-slider.owl-carousel').find('.owl-prev').html("<svg class='svg-next-icon svg-next-icon-size-16' style='fill:#666'><use xlink:href='#icon-left-owlCarousel'></use></svg>");
                        }, 1500);
                    });
                }
                // X? l� variant
                if ($('#form-quickview select[data-option=option1] option').length > 0) {
                    $('#form-quickview .opt1-quickview').children('label').html(product.options[0]);
                    var checked = $('#form-quickview select[data-option=option1]').val();
                    $('#form-quickview select[data-option=option1] option').each(function () {
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
                            $('.data-opt1-quickview').append("<li class='" + arr_opt + "'><label><input checked='checked' type='radio' value='" + $(this).val() + "' name='option1'><span>" + $(this).val() + "</span></label></li>");
                        } else {
                            $('.data-opt1-quickview').append("<li class='" + arr_opt + "'><label><input type='radio' value='" + $(this).val() + "' name='option1'><span>" + $(this).val() + "</span></label></li>");
                        }
                    });
                } else {
                    $('#form-quickview .opt1-quickview').remove();
                }
                if ($('#form-quickview select[data-option=option2] option').length > 0) {
                    $('#form-quickview .opt2-quickview').children('label').html(product.options[1]);
                    var checked = $('#form-quickview select[data-option=option2]').val();
                    $('#form-quickview select[data-option=option2] option').each(function () {
                        var arr_opt = '';
                        var opt_select_2 = $(this).val();
                        $.each(product.variants, function (i, v) {
                            var opt2 = v.option2;
                            if (opt_select_2 == opt2 && v.available) {
                                arr_opt = arr_opt + ' ' + slug(v.option1);
                            }
                        });
                        if ($(this).val() == checked) {
                            $('.data-opt2-quickview').append("<li class='" + arr_opt + "'><label><input checked='checked' type='radio' value='" + $(this).val() + "' name='option2'><span>" + $(this).val() + "</span></label></li>");
                        } else {
                            $('.data-opt2-quickview').append("<li class='" + arr_opt + "'><label><input type='radio' value='" + $(this).val() + "' name='option2'><span>" + $(this).val() + "</span></label></li>");
                        }
                    });
                } else {
                    $('#form-quickview .opt2-quickview').remove();
                }
                if ($('#form-quickview select[data-option=option3] option').length > 0) {
                    $('#form-quickview .opt3-quickview').children('label').html(product.options[2]);
                    var checked = $('#form-quickview select[data-option=option3]').val();
                    $('#form-quickview select[data-option=option3] option').each(function () {
                        var arr_opt = '';
                        var opt_select_3 = $(this).val();
                        $.each(product.variants, function (i, v) {
                            var opt3 = v.option3;
                            if (opt_select_3 == opt3 && v.available) {
                                arr_opt = arr_opt + ' ' + slug(v.option1 + '-' + v.option2);
                            }
                        });
                        if ($(this).val() == checked) {
                            $('.data-opt3-quickview').append("<li class='" + arr_opt + "'><label><input checked='checked' type='radio' value='" + $(this).val() + "' name='option3'><span>" + $(this).val() + "</span></label></li>");
                        } else {
                            $('.data-opt3-quickview').append("<li class='" + arr_opt + "'><label><input type='radio' value='" + $(this).val() + "' name='option3'><span>" + $(this).val() + "</span></label></li>");
                        }
                    });
                } else {
                    $('#form-quickview .opt3-quickview').remove();
                }
            }
        });
        return false;
    }
    //final width --> this is the quick view image slider width
    //maxQuickWidth --> this is the max-width of the quick-view panel
    var sliderFinalWidth = 500,
            maxQuickWidth = 900;

    //open the quick view panel
    jQuery(document).on("click", ".quickview", function (event) {
        var selectedImage = $(this).parents('.product-wrapper').find('.product-image img'),
                slectedImageUrl = selectedImage.attr('src');
        quickViewProduct($(this).attr('data-handle'));
        $('body').addClass('overlay-layer');

        animateQuickView(selectedImage, sliderFinalWidth, maxQuickWidth, 'open');

        //update the visible slider image in the quick view panel
        //you don't need to implement/use the updateQuickView if retrieving the quick view data with ajax
        updateQuickView(slectedImageUrl);
        setTimeout(function () {
            $('.quickview-slider').addClass('is-visible-slide');
        }, 1700);
        setTimeout(function () {
            jQuery('#form-quickview ul.data-opt1-quickview li:visible label').first().click();
        }, 1800);
    });

    jQuery(document).on('click', '#form-quickview ul.data-opt1-quickview li', function () {
        var v_opt1 = jQuery(this).find('span').html();
        jQuery('#form-quickview select[data-option=option1]').val(v_opt1).change();
        if (jQuery('#form-quickview ul.data-opt2-quickview li:visible').length > 0) {
            jQuery('#form-quickview ul.data-opt2-quickview li').hide();
            jQuery('#form-quickview ul.data-opt2-quickview li.' + slug(v_opt1)).show();
            jQuery('#form-quickview ul.data-opt2-quickview li:visible label')[0].click();
        }
    });
    jQuery(document).on('click', '#form-quickview ul.data-opt2-quickview li', function () {
        var v_opt1 = slug(jQuery('#form-quickview select[data-option=option1]').val());
        var v_opt2 = jQuery(this).find('span').html();
        var both_v_opt = v_opt1 + '-' + slug(v_opt2);
        jQuery('#form-quickview select[data-option=option2]').val(v_opt2).change();
        if (jQuery('#form-quickview ul.data-opt3-quickview li:visible').length > 0) {
            jQuery('#form-quickview ul.data-opt3-quickview li').hide();
            jQuery('#form-quickview ul.data-opt3-quickview li.' + both_v_opt).show();
            jQuery('#form-quickview ul.data-opt3-quickview li:visible label')[0].click();
        }
    });
    jQuery(document).on('click', '#form-quickview ul.data-opt3-quickview li', function () {
        var v_opt3 = $(this).find('span').html();
        jQuery('#form-quickview select[data-option=option3]').val(v_opt3).change();
    });

    $('.wrapper-quickview').on('click', '.product-thumb a', function () {
        item = $('.wrapper-quickview');
        item.find('.quickview-image img').attr('src', $(this).attr('data-image'));
        item.find('.product-thumb a').removeClass('active');
        $(this).addClass('active');
        return false;
    });
    //close the quick view panel
    $('body').on('click', function (event) {
        if ($(event.target).is('.quickview-close') || $(event.target).is('body.overlay-layer')) {
            $('#quickview-sliderproduct .quickview-slider').hide();
            closeQuickView(sliderFinalWidth, maxQuickWidth);
        }
    });
    $(document).on("click", ".quickview-close a", function () {
        $('#quickview-sliderproduct .quickview-slider').hide();
        closeQuickView(sliderFinalWidth, maxQuickWidth);
    });
    $(document).keyup(function (event) {
        //check if user has pressed 'Esc'
        if (event.which == '27') {
            $('#quickview-sliderproduct .quickview-slider').hide();
            closeQuickView(sliderFinalWidth, maxQuickWidth);
        }
    });

    //center quick-view on window resize
    $(window).on('resize', function () {
        if ($('.wrapper-quickview').hasClass('is-visible')) {
            window.requestAnimationFrame(resizeQuickView);
        }
    });

    function updateQuickView(url) {
        $('.wrapper-quickview .quickview-image').find('img').attr('src', Haravan.resizeImage(destroyResize(url), 'large'));
    }

    function resizeQuickView() {
        var quickViewLeft = ($(window).width() - $('.wrapper-quickview').width()) / 2,
                quickViewTop = ($(window).height() - $('.wrapper-quickview').height()) / 2;
        $('.wrapper-quickview').css({
            "top": quickViewTop,
            "left": quickViewLeft,
        });
    }

    function closeQuickView(finalWidth, maxQuickWidth) {
        var close = $('.quickview-close'),
                activeSliderUrl = close.parents('.wrapper-quickview').find('.quickview-image img').attr('src'),
                selectedImage = $('.product-wrapper').find('.image-selected').find('img');
        //update the image in the gallery
        if (!$('.wrapper-quickview').hasClass('velocity-animating') && $('.wrapper-quickview').hasClass('is-visible-info')) {
            selectedImage.attr('src');
            animateQuickView(selectedImage, finalWidth, maxQuickWidth, 'close');
        } else {
            closeNoAnimation(selectedImage, finalWidth, maxQuickWidth);
        }
    }

    function animateQuickView(image, finalWidth, maxQuickWidth, animationType) {
        //store some image data (width, top position, ...)
        //store window data to calculate quick view panel position
        var parentListItem = image.parents('.product-image'),
                topSelected = image.offset().top - $(window).scrollTop(),
                leftSelected = image.offset().left,
                widthSelected = image.width(),
                heightSelected = image.height(),
                windowWidth = $(window).width(),
                windowHeight = $(window).height(),
                finalLeft = (windowWidth - finalWidth) / 2,
                finalHeight = finalWidth * heightSelected / widthSelected,
                finalTop = (windowHeight - finalHeight) / 2,
                quickViewWidth = (windowWidth * .8 < maxQuickWidth) ? windowWidth * .8 : maxQuickWidth,
                quickViewLeft = (windowWidth - quickViewWidth) / 2;
        if (animationType == 'open') {
            //hide the image in the gallery
            parentListItem.addClass('image-selected');
            //place the quick view over the image gallery and give it the dimension of the gallery image
            $('.wrapper-quickview > div').eq(0).addClass('col-md-5');
            $('.wrapper-quickview > div').eq(1).addClass('col-md-7');
            $('.wrapper-quickview').css({
                "top": topSelected,
                "left": leftSelected,
                "width": widthSelected,
            }).velocity({
                //animate the quick view: animate its width and center it in the viewport
                //during this animation, only the slider image is visible
                'top': finalTop + 'px',
                'left': finalLeft + 'px',
                'width': finalWidth + 'px',
            }, 1000, [400, 20], function () {
                //animate the quick view: animate its width to the final value
                $('.wrapper-quickview').addClass('animate-width').velocity({
                    'left': quickViewLeft + 'px',
                    'width': quickViewWidth + 'px',
                }, 300, 'ease', function () {
                    //show quick view content
                    $('.wrapper-quickview').addClass('is-visible-info');
                });
            }).addClass('is-visible');
        } else {
            $('.wrapper-quickview > div').eq(0).removeClass('col-md-5').addClass('col-md-12');
            $('.wrapper-quickview > div').eq(1).removeClass('col-md-7');
            //close the quick view reverting the animation
            parentListItem.removeClass('image-selected');
            $('.wrapper-quickview').removeClass('is-visible-info').velocity({
                'top': finalTop + 'px',
                'left': finalLeft + 'px',
                'width': finalWidth + 'px',
            }, 300, 'ease', function () {
                $('body').removeClass('overlay-layer');
                $('.wrapper-quickview').removeClass('animate-width').velocity({
                    "top": topSelected,
                    "left": leftSelected,
                    "width": widthSelected,
                }, 500, 'ease', function () {
                    $('.wrapper-quickview').removeClass('is-visible');
                });
            });
        }
    }

    function closeNoAnimation(image, finalWidth, maxQuickWidth) {
        var parentListItem = image.parent('.product-image'),
                topSelected = image.offset().top - $(window).scrollTop(),
                leftSelected = image.offset().left,
                widthSelected = image.width();
        //close the quick view reverting the animation
        $('body').removeClass('overlay-layer');
        parentListItem.removeClass('image-selected');
        $('.wrapper-quickview').velocity("stop").removeClass('is-visible-info animate-width is-visible').css({
            "top": topSelected,
            "left": leftSelected,
            "width": widthSelected,
        });
    }
});