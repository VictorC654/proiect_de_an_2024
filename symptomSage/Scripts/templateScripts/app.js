/* Template Name: Minton - Bootstrap 4 Landing Page Tamplat
   Author: CoderThemes
   File Description: Main JS file of the template
*/


! function($) {
    "use strict";

    var Minton = function() {};

    Minton.prototype.initStickyMenu = function() {
        $(window).scroll(function() {
            var scroll = $(window).scrollTop();
        
            if (scroll >= 50) {
                $(".sticky").addClass("nav-sticky");
            } else {
                $(".sticky").removeClass("nav-sticky");
            }
        });
    },


    Minton.prototype.init = function() {
        this.initStickyMenu();
    },
    //init
    $.Minton = new Minton, $.Minton.Constructor = Minton
}(window.jQuery),

//initializing
function($) {
    "use strict";
    $.Minton.init();
}(window.jQuery);