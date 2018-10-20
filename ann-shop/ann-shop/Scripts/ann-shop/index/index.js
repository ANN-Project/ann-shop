$(document).ready(function () {
    Init()
    HandleControl()
});

function Init() {
}

function HandleControl() {
    // Handle for device mobile
    HMobileNav()

    // Handle for desktop
    HDeskNav();
}

/*************************************/
/*          Menu JS                  */
/*************************************/
// Handle for device mobile
function HMobileNav() {
    $('nav#menu-mobile').mmenu();

    flagg = true;

    if (flagg) {
        $('.click-menu-mobile a').click(function () {
            $('#menu-mobile').removeClass('hidden');
            flagg = false;
        })
    }
}

// Handle for desktop
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
