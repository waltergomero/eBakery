!function(e,t){var n=function(e){var t={};function n(i){if(t[i])return t[i].exports;var o=t[i]={i:i,l:!1,exports:{}};return e[i].call(o.exports,o,o.exports,n),o.l=!0,o.exports}return n.m=e,n.c=t,n.d=function(e,t,i){n.o(e,t)||Object.defineProperty(e,t,{configurable:!1,enumerable:!0,get:i})},n.r=function(e){Object.defineProperty(e,"__esModule",{value:!0})},n.n=function(e){var t=e&&e.__esModule?function(){return e.default}:function(){return e};return n.d(t,"a",t),t},n.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},n.p="",n(n.s=451)}({451:function(e,t,n){"use strict";Object.defineProperty(t,"__esModule",{value:!0});var i=function(){function e(e,t){for(var n=0;n<t.length;n++){var i=t[n];i.enumerable=i.enumerable||!1,i.configurable=!0,"value"in i&&(i.writable=!0),Object.defineProperty(e,i.key,i)}}return function(t,n,i){return n&&e(t.prototype,n),i&&e(t,i),t}}(),o=function(){function e(t){var n=arguments.length>1&&void 0!==arguments[1]?arguments[1]:{};!function(e,t){if(!(e instanceof t))throw new TypeError("Cannot call a class as a function")}(this,e),this._onHover="hover"===n.trigger||"hover"===t.getAttribute("data-trigger"),this._container=this._findParent(t,"mega-dropdown"),this._container&&(this._menu=this._container.querySelector(".dropdown-toggle ~ .dropdown-menu"),this._menu&&(t.setAttribute("aria-expanded","false"),this._el=t,this._bindEvents()))}return i(e,[{key:"open",value:function(){this._timeout&&(clearTimeout(this._timeout),this._timeout=null),this._focusTimeout&&(clearTimeout(this._focusTimeout),this._focusTimeout=null),"true"!==this._el.getAttribute("aria-expanded")&&(this._triggerEvent("show"),this._container.classList.add("show"),this._menu.classList.add("show"),this._el.setAttribute("aria-expanded","true"),this._el.focus(),this._triggerEvent("shown"))}},{key:"close",value:function(e){var t=this;this._timeout&&(clearTimeout(this._timeout),this._timeout=null),this._focusTimeout&&(clearTimeout(this._focusTimeout),this._focusTimeout=null),this._onHover&&!e?this._timeout=setTimeout(function(){t._timeout&&(clearTimeout(t._timeout),t._timeout=null),t._close()},150):this._close()}},{key:"toggle",value:function(){"true"===this._el.getAttribute("aria-expanded")?this.close(!0):this.open()}},{key:"destroy",value:function(){this._unbindEvents(),this._el=null,this._timeout&&(clearTimeout(this._timeout),this._timeout=null),this._focusTimeout&&(clearTimeout(this._focusTimeout),this._focusTimeout=null)}},{key:"_close",value:function(){"true"===this._el.getAttribute("aria-expanded")&&(this._triggerEvent("hide"),this._container.classList.remove("show"),this._menu.classList.remove("show"),this._el.setAttribute("aria-expanded","false"),this._triggerEvent("hidden"))}},{key:"_bindEvents",value:function(){var e=this;this._elClickEvnt=function(t){t.preventDefault(),e.toggle()},this._el.addEventListener("click",this._elClickEvnt),this._bodyClickEvnt=function(t){!e._container.contains(t.target)&&e._container.classList.contains("show")&&e.close(!0)},document.body.addEventListener("click",this._bodyClickEvnt,!0),this._menuClickEvnt=function(t){t.target.classList.contains("mega-link")&&e.close(!0)},this._menu.addEventListener("click",this._menuClickEvnt,!0),this._focusoutEvnt=function(t){e._focusTimeout&&(clearTimeout(e._focusTimeout),e._focusTimeout=null),"true"===e._el.getAttribute("aria-expanded")&&(e._focusTimeout=setTimeout(function(){"BODY"!==document.activeElement.tagName.toUpperCase()&&e._findParent(document.activeElement,"mega-dropdown")!==e._container&&e.close(!0)},100))},this._container.addEventListener("focusout",this._focusoutEvnt,!0),this._onHover&&(this._enterEvnt=function(t){"static"!==window.getComputedStyle(e._menu,null).getPropertyValue("position")&&e.open()},this._leaveEvnt=function(t){"static"!==window.getComputedStyle(e._menu,null).getPropertyValue("position")&&e.close()},this._el.addEventListener("mouseenter",this._enterEvnt),this._menu.addEventListener("mouseenter",this._enterEvnt),this._el.addEventListener("mouseleave",this._leaveEvnt),this._menu.addEventListener("mouseleave",this._leaveEvnt))}},{key:"_unbindEvents",value:function(){this._elClickEvnt&&(this._el.removeEventListener("click",this._elClickEvnt),this._elClickEvnt=null),this._bodyClickEvnt&&(document.body.removeEventListener("click",this._bodyClickEvnt,!0),this._bodyClickEvnt=null),this._menuClickEvnt&&(this._menu.removeEventListener("click",this._menuClickEvnt,!0),this._menuClickEvnt=null),this._focusoutEvnt&&(this._container.removeEventListener("focusout",this._focusoutEvnt,!0),this._focusoutEvnt=null),this._enterEvnt&&(this._el.removeEventListener("mouseenter",this._enterEvnt),this._menu.removeEventListener("mouseenter",this._enterEvnt),this._enterEvnt=null),this._leaveEvnt&&(this._el.removeEventListener("mouseleave",this._leaveEvnt),this._menu.removeEventListener("mouseleave",this._leaveEvnt),this._leaveEvnt=null)}},{key:"_findParent",value:function(e,t){if("BODY"===e.tagName.toUpperCase())return null;for(e=e.parentNode;"BODY"!==e.tagName.toUpperCase()&&!e.classList.contains(t);)e=e.parentNode;return"BODY"!==e.tagName.toUpperCase()?e:null}},{key:"_triggerEvent",value:function(e){if(document.createEvent){var t=void 0;"function"==typeof Event?t=new Event(e):(t=document.createEvent("Event")).initEvent(e,!1,!0),this._container.dispatchEvent(t)}else this._container.fireEvent("on"+e,document.createEventObject())}}]),e}();t.MegaDropdown=o}});if("object"==typeof n){var i=["object"==typeof module&&"object"==typeof module.exports?module.exports:null,"undefined"!=typeof window?window:null,e&&e!==window?e:null];for(var o in n)i[0]&&(i[0][o]=n[o]),i[1]&&"__esModule"!==o&&(i[1][o]=n[o]),i[2]&&(i[2][o]=n[o])}}(this);