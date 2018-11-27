/* -------------------------------------
		CUSTOM FUNCTION WRITE HERE
-------------------------------------- */
"use strict";
jQuery(document).on('ready', function() {
	/* --------------------------------------
			SEARCH FORM
	-------------------------------------- */
	jQuery('.tg-btnsearch').on('click', function(){
		jQuery('.tg-searchbox').slideToggle();
	});
	/* -------------------------------------
			LOCATIONS TOGGLE
	-------------------------------------- */
	jQuery("#tg-locationbtn").on("click", function(){
		jQuery("body").toggleClass('tg-showlocations');
	});
	/* -------------------------------------
			COLLAPSE MENU SMALL DEVICES
	-------------------------------------- */
	function collapseMenu(){
		jQuery('.menu-item-has-children').prepend('<span class="tg-dropdowarrow"><i class="icon-chevron-right"></i></span>');
		jQuery('.menu-item-has-children span').on('click', function() {
			jQuery(this).next().next().slideToggle(300);
			jQuery(this).parent('.menu-item-has-children').toggleClass('tg-open');
		});
	}
	collapseMenu();
	/* -------------------------------------
			HOME BANNER SLIDER				
	-------------------------------------- */
	var _tg_homeslidervone = jQuery('#tg-homeslidervone');
	_tg_homeslidervone.pogoSlider({
		pauseOnHover: false,
		autoplay: true,
		generateNav: false,
		displayProgess: false,
		autoplayTimeout: 6000,
		targetHeight: 445,
		responsive: true,
		onSlideStart: (function(){
			var _slideslength = jQuery('.pogoSlider-slide').length;
			var _currentSlide = this.currentSlideIndex + 1;
			jQuery('#tg-totalslides').text(_slideslength);
			jQuery('#tg-currentslide').text(_currentSlide);
		}),
	}).data('plugin_pogoSlider');
	/* -------------------------------------
			MAGA MENU
	-------------------------------------- */
	function hoverIn() {
		var a = jQuery(this);
		var nav = a.closest('#tg-navigation');
		var mega = a.find('.mega-menu');
		var offset = rightSide(nav) - leftSide(a);
		mega.width(Math.min(rightSide(nav), columns(mega) * 290));
		mega.css('left', Math.min(0, offset - mega.width()));
	}
	function hoverOut() {}
	function columns(mega) {
		var columns = 0;
		mega.children('.mega-menu-row').each(function () {
			columns = Math.max(columns, jQuery(this).children('.mega-menu-col').length);
		});
		return columns;
	}
	function leftSide(elem) {
		return elem.offset().left;
	}
	function rightSide(elem) {
		return elem.offset().left + elem.width();
	}
	jQuery('#tg-navigation .menu-item-has-mega-menu').hover(hoverIn, hoverOut);
	/* -------------------------------------
			PRETTY PHOTO GALLERY
	-------------------------------------- */
	jQuery("a[data-rel]").each(function () {
		jQuery(this).attr("rel", jQuery(this).data("rel"));
	});
	jQuery("a[data-rel^='prettyPhoto']").prettyPhoto({
		animation_speed: 'normal',
		theme: 'dark_square',
		slideshow: 3000,
		autoplay_slideshow: false,
		social_tools: false
	});
	/* -------------------------------------
			TESTIMONIALS SLIDER
	-------------------------------------- */
	function testimonialSlider(){
		var sync1 = jQuery('#tg-testimonialslider');
		var sync2 = jQuery('#tg-authorpicslider');
		var slidesPerPage = 5;
		var syncedSecondary = true;
		sync1.owlCarousel({
			items : 1,
			loop: true,
			nav: false,
			dots: false,
			autoplay: true,
			slideSpeed : 2000,
			responsiveRefreshRate : 200,
		}).on('changed.owl.carousel', syncPosition);
		sync2.on('initialized.owl.carousel', function () {
			sync2.find(".owl-item").eq(0).addClass("current");
		})
		.owlCarousel({
			items : slidesPerPage,
			dots: false,
			nav: false,
			margin: 10,
			smartSpeed: 200,
			slideSpeed : 500,
			slideBy: slidesPerPage,
			responsiveRefreshRate : 100,
		}).on('changed.owl.carousel', syncPosition2);
		function syncPosition(el) {
			var count = el.item.count-1;
			var current = Math.round(el.item.index - (el.item.count/2) - .5);
			if(current < 0) {
				current = count;
			}
			if(current > count) {
				current = 0;
			}
			sync2
			.find(".owl-item")
			.removeClass("current")
			.eq(current)
			.addClass("current")
			var onscreen = sync2.find('.owl-item.active').length - 1;
			var start = sync2.find('.owl-item.active').first().index();
			var end = sync2.find('.owl-item.active').last().index();
			if (current > end) {
				sync2.data('owl.carousel').to(current, 100, true);
			}
			if (current < start) {
				sync2.data('owl.carousel').to(current - onscreen, 100, true);
			}
		}
		function syncPosition2(el) {
			if(syncedSecondary) {
				var number = el.item.index;
				sync1.data('owl.carousel').to(number, 100, true);
			}
		}
		sync2.on("click", ".owl-item", function(e){
			e.preventDefault();
			var number = jQuery(this).index();
			sync1.data('owl.carousel').to(number, 300, true);
		});
	}
	testimonialSlider();
	/* -------------------------------------
			SERVICES SLIDER
	-------------------------------------- */
	var _tg_servicesslider = jQuery('#tg-servicesslider');
	_tg_servicesslider.owlCarousel({
		margin: 30,
		loop: true,
		dots: true,
		nav: false,
		responsiveClass:true,
		autoplay: true,
		navText: [
			'<i class="icon-arrow-left"></i>',
			'<i class="icon-arrow-right"></i>',
		],
		navClass: [
			'tg-btnsimpleprev tg-btnprev',
			'tg-btnsimplenext tg-btnnext'
		],
		responsive : {
			0 : {
				items:1,
			},
			568 : {
				items:2,
			},
			768 : {
				items:3,
			},
			992 : {
				items:3,
			},
			1200 : {
				items:4,
			}
		}
	});
	/* -------------------------------------
			SERVICES SLIDER
	-------------------------------------- */
	var _tg_eventslider = jQuery('#tg-eventslider');
	_tg_eventslider.owlCarousel({
		margin: 30,
		loop: true,
		dots: true,
		nav: false,
		responsiveClass:true,
		autoplay: false,
		navText: [
			'<i class="icon-arrow-left"></i>',
			'<i class="icon-arrow-right"></i>',
		],
		navClass: [
			'tg-btnsimpleprev tg-btnprev',
			'tg-btnsimplenext tg-btnnext'
		],
		responsive : {
			0 : {
				items:1,
			},
			568 : {
				items:2,
			},
			768 : {
				items:3,
			},
			992 : {
				items:3,
			},
			1200 : {
				items:4,
			}
		}
	});
	/* -------------------------------------
			COUNTER
	-------------------------------------- */
	var _tg_counters = jQuery('#tg-statisticscounters');
	_tg_counters.appear(function () {
		var _tg_counter = jQuery('.tg-counter > h2 > span');
		_tg_counter.countTo();
	});
	/* -------------------------------------
			SERVICES SLIDER
	-------------------------------------- */
	var _tg_expertsslider = jQuery('#tg-expertsslider');
	_tg_expertsslider.owlCarousel({
		margin: 30,
		loop: true,
		dots: true,
		nav: false,
		responsiveClass:true,
		autoplay: true,
		navText: [
			'<i class="icon-arrow-left"></i>',
			'<i class="icon-arrow-right"></i>',
		],
		navClass: [
			'tg-btnsimpleprev tg-btnprev',
			'tg-btnsimplenext tg-btnnext'
		],
		responsive : {
			0 : {
				items:1,
			},
			568 : {
				items:2,
			},
			768 : {
				items:3,
			},
			992 : {
				items:4,
			},
			1200 : {
				items:4,
			}
		}
	});
	/* -------------------------------------
			RELATED EXPERTS SLIDER
	-------------------------------------- */
	var _tg_expertsslider = jQuery('#tg-expertsslider-vtwo');
	_tg_expertsslider.owlCarousel({
		margin: 30,
		loop: true,
		dots: true,
		nav: false,
		autoplay: true,
		responsiveClass:true,
		navText: [
			'<i class="icon-arrow-left"></i>',
			'<i class="icon-arrow-right"></i>',
		],
		navClass: [
			'tg-btnsimpleprev tg-btnprev',
			'tg-btnsimplenext tg-btnnext'
		],
		responsive : {
			0 : {
				items:1,
			},
			480 : {
				items:2,
			},
			768 : {
				items:2,
			},
			992 : {
				items:2,
			},
			1200 : {
				items:3,
			}
		}
	});
	/* -------------------------------------
			TESTIMONIAL IMAGE SLIDER
	-------------------------------------- */
	var _tg_servicesslider = jQuery('#tg-imgvideoslider');
	_tg_servicesslider.owlCarousel({
		items: 1,
		loop: true,
		dots: false,
		nav: true,
		responsiveClass:true,
		autoplay: true,
		navText: [
			'<i class="icon-chevron-left"></i>',
			'<i class="icon-chevron-right"></i>',
		],
		navClass: [
			'tg-btnsimpleprev tg-btnprev',
			'tg-btnsimplenext tg-btnnext'
		],
	});
	/* -------------------------------------
			BANNER 5 SLIDER
	-------------------------------------- */
	var _tg_successslider = jQuery('#tg-successslider');
	_tg_successslider.owlCarousel({
		items: 1,
		loop: true,
		dots: false,
		nav: true,
		responsiveClass:true,
		autoplay: true,
		animateOut: 'fadeOut',
		navText: [
			'<i class="icon-chevron-left"></i>',
			'<i class="icon-chevron-right"></i>',
		],
		navClass: [
			'tg-btnroundprev',
			'tg-btnroundnext'
		],
	});
	/* -------------------------------------
			THEME ACCORDION
	-------------------------------------- */
	function themeAccordion() {
		jQuery('.tg-panelcontent').hide();
		jQuery('.tg-accordion h4:first').addClass('active').next().slideDown('slow');
		jQuery('.tg-accordion h4').on('click',function() {
			if(jQuery(this).next().is(':hidden')) {
				jQuery('.tg-accordion h4').removeClass('active').next().slideUp('slow');
				jQuery(this).toggleClass('active').next().slideDown('slow');
			}
		});
	}
	themeAccordion();
	/* -------------------------------------
			THEME TOGGLES
	-------------------------------------- */
	jQuery("#tg-themetoggles").on('click', '.tg-panneltitle', function (e) {
		jQuery(this).next('.tg-pannelcontent').slideToggle(200);
		jQuery(this).parents('.tg-pannel').toggleClass('tg-active');
	});
	/* -------------------------------------
			NEXT EVENT COUNTER
	-------------------------------------- */
	//jQuery('.tg-upcomingeventcounter').countdown('2017/12/12', function(event) {
	//	var $this = jQuery(this).html(event.strftime(''
	//		+ '<div class="tg-eventcounter"><span>%-D</span><span>D</span></div>'
	//		+ '<div class="tg-eventcounter"><span>%H</span><span>H</span></div>'
	//		+ '<div class="tg-eventcounter"><span>%M</span><span>M</span></div>'
	//		+ '<div class="tg-eventcounter"><span>%S</span><span>S</span></div>'
	//	));
	//});
	
	/* -------------------------------------
			SERVICES SLIDER
	-------------------------------------- */
	var _tg_servicesslider = jQuery('#tg-promotionnalslider');
	_tg_servicesslider.owlCarousel({
		items: 1,
		loop: true,
		dots: true,
		nav: false,
		autoplay: false,
		navText: [
			'<i class="icon-arrow-left"></i>',
			'<i class="icon-arrow-right"></i>',
		],
	});
	/* -------------------------------------
			CALENDAR
	-------------------------------------- */
	jQuery('#tg-datepicker')
	.datepicker({
		format: 'dd/mm/yyyy'
	})
	/* -------------------------------------
			EVENT PROGRAM SLIDER
	-------------------------------------- */
	var _tg_expertsslider = jQuery('#tg-eventprogramslider');
	_tg_expertsslider.owlCarousel({
		items: 1,
		loop: true,
		dots: false,
		nav: true,
		autoplay: true,
		navText: [
			'<i class="icon-arrow-left"></i>',
			'<i class="icon-arrow-right"></i>',
		],
		navClass: [
			'tg-btnsimpleprev tg-btnprev',
			'tg-btnsimplenext tg-btnnext'
		]
	});
	/* -------------------------------------
			EVENT SPEAKER SLIDER
	-------------------------------------- */
	var _tg_expertsslider = jQuery('#tg-eventspeakerslider');
	_tg_expertsslider.owlCarousel({
		items: 1,
		loop: true,
		dots: false,
		nav: true,
		autoplay: true,
		navText: [
			'<i class="icon-arrow-left"></i>',
			'<i class="icon-arrow-right"></i>',
		],
		navClass: [
			'tg-btnsimpleprev tg-btnprev',
			'tg-btnsimplenext tg-btnnext'
		]
	});
	/* ---------------------------------------
			GALLERY FILTERABLE
	-------------------------------------- */
	var $container = jQuery('.tg-galleryfilterable');
	var $optionSets = jQuery('.tg-optionset');
	var $optionLinks = $optionSets.find('a');
	function doIsotopeFilter() {
		if (jQuery().isotope) {
			var isotopeFilter = '';
			$optionLinks.each(function () {
				var selector = jQuery(this).attr('data-filter');
				var link = window.location.href;
				var firstIndex = link.indexOf('filter=');
				if (firstIndex > 0) {
					var id = link.substring(firstIndex + 7, link.length);
					if ('.' + id == selector) {
						isotopeFilter = '.' + id;
					}
				}
			});
			//$(window).load(function () {
				$container.isotope({
					//itemSelector: '.tg-productitem',
					filter: isotopeFilter
				});
			//});
			$optionLinks.each(function () {
				var $this = jQuery(this);
				var selector = $this.attr('data-filter');
				if (selector == isotopeFilter) {
					if (!$this.hasClass('tg-active')) {
						var $optionSet = $this.parents('.option-set');
						$optionSet.find('.tg-active').removeClass('tg-active');
						$this.addClass('tg-active');
					}
				}
			});
			$optionLinks.on('click', function () {
				var $this = jQuery(this);
				var selector = $this.attr('data-filter');
				$container.isotope({itemSelector: '.tg-project', filter: selector});
				if (!$this.hasClass('tg-active')) {
					var $optionSet = $this.parents('.tg-optionset');
					$optionSet.find('.tg-active').removeClass('tg-active');
					$this.addClass('tg-active');
				}
				return false;
			});
		}
	}
	var isotopeTimer = window.setTimeout(function () {
		window.clearTimeout(isotopeTimer);
		doIsotopeFilter();
	}, 1000);
	/*------------------------------------------
			PRODUCT INCREASE
	------------------------------------------*/
	jQuery('em.minus').on('click', function () {
		jQuery('#quantity1').val(parseInt(jQuery('#quantity1').val(), 10) - 1);
	});
	jQuery('em.plus').on('click', function () {
		jQuery('#quantity1').val(parseInt(jQuery('#quantity1').val(), 10) + 1);
	});
	/* -------------------------------------
			SERVICES SLIDER
	-------------------------------------- */
	var _tg_expertsslider = jQuery('#tg-relatedproductslider');
	_tg_expertsslider.owlCarousel({
		margin: 30,
		loop: true,
		dots: true,
		nav: false,
		autoplay: true,
		responsiveClass:true,
		navText: [
			'<i class="icon-arrow-left"></i>',
			'<i class="icon-arrow-right"></i>',
		],
		navClass: [
			'tg-btnsimpleprev tg-btnprev',
			'tg-btnsimplenext tg-btnnext'
		],
		responsive : {
			0 : {
				items:1,
			},
			480 : {
				items:2,
			},
			568 : {
				items:3,
			},
			768 : {
				items:2,
			},
			992 : {
				items:3,
			},
			1200 : {
				items:3,
			}
		}
	});
	/* -------------------------------------
			TESTIMONIALS SLIDER
	-------------------------------------- */
	function productSlider(){
		var sync1 = jQuery('#tg-productdetailslider');
		var sync2 = jQuery('#tg-producttumbslider');
		var slidesPerPage = 4;
		var syncedSecondary = true;
		sync1.owlCarousel({
			items : 1,
			loop: true,
			nav: false,
			dots: false,
			autoplay: true,
			slideSpeed : 2000,
			responsiveRefreshRate : 200,
		}).on('changed.owl.carousel', syncPosition);
		sync2.on('initialized.owl.carousel', function () {
			sync2.find(".owl-item").eq(0).addClass("current");
		})
		.owlCarousel({
			items : slidesPerPage,
			dots: false,
			nav: false,
			smartSpeed: 200,
			slideSpeed : 500,
			slideBy: slidesPerPage,
			responsiveRefreshRate : 100,
			
		}).on('changed.owl.carousel', syncPosition2);
		function syncPosition(el) {
			var count = el.item.count-1;
			var current = Math.round(el.item.index - (el.item.count/2) - .5);
			if(current < 0) {
				current = count;
			}
			if(current > count) {
				current = 0;
			}
			sync2
			.find(".owl-item")
			.removeClass("current")
			.eq(current)
			.addClass("current")
			var onscreen = sync2.find('.owl-item.active').length - 1;
			var start = sync2.find('.owl-item.active').first().index();
			var end = sync2.find('.owl-item.active').last().index();
			if (current > end) {
				sync2.data('owl.carousel').to(current, 100, true);
			}
			if (current < start) {
				sync2.data('owl.carousel').to(current - onscreen, 100, true);
			}
		}
		function syncPosition2(el) {
			if(syncedSecondary) {
				var number = el.item.index;
				sync1.data('owl.carousel').to(number, 100, true);
			}
		}
		sync2.on("click", ".owl-item", function(e){
			e.preventDefault();
			var number = jQuery(this).index();
			sync1.data('owl.carousel').to(number, 300, true);
		});
	}
	productSlider();
	/* -------------------------------------
			PROGRESS BAR
	-------------------------------------- */
	try {
		jQuery('#tg-skills').appear(function () {
			jQuery('.tg-skillholder').each(function () {
				jQuery(this).find('.tg-skillbar').animate({
					width: jQuery(this).attr('data-percent')
				}, 2500);
			});
		});
	} catch (err) {}
	/* -------------------------------------
			EVENT COUNTER
	-------------------------------------- */
	jQuery('.tg-eventgrid-vtwo .tg-event, .tg-eventlist-vtwo .tg-event').on('mouseover', function(){
		jQuery(this).addClass('tg-showcounter');
	});
	jQuery('.tg-eventgrid-vtwo .tg-event, .tg-eventlist-vtwo .tg-event').on('mouseout', function(){
		jQuery(this).removeClass('tg-showcounter');
	});
	/* -------------------------------------
			THEME TOGGLES
	-------------------------------------- */
	jQuery('#tg-themetoggles .tg-panneltitle').on('click', 'a', function () {
		jQuery(this).next('.tg-pannelcontent').slideToggle(200);
		jQuery(this).parent('.tg-pannel').toggleClass('tg-active');
	});
	/* -------------------------------------
			TOOLTIP
	-------------------------------------- */
	jQuery('[data-toggle="tooltip"]').tooltip()
	/* -------------------------------------
			FLIP BOX
	-------------------------------------- */
	jQuery('.tg-flippanel').hover(function(){
		jQuery(this).addClass('tg-flip');
	},function(){
		jQuery(this).removeClass('tg-flip');
	});
});