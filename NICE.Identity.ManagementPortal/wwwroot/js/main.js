(function(a){function b(d){if(c[d])return c[d].exports;var e=c[d]={i:d,l:!1,exports:{}};return a[d].call(e.exports,e,e.exports,b),e.l=!0,e.exports}var c={};return b.m=a,b.c=c,b.d=function(a,c,d){b.o(a,c)||Object.defineProperty(a,c,{enumerable:!0,get:d})},b.r=function(a){'undefined'!=typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(a,Symbol.toStringTag,{value:'Module'}),Object.defineProperty(a,'__esModule',{value:!0})},b.t=function(a,c){if(1&c&&(a=b(a)),8&c)return a;if(4&c&&'object'==typeof a&&a&&a.__esModule)return a;var d=Object.create(null);if(b.r(d),Object.defineProperty(d,'default',{enumerable:!0,value:a}),2&c&&'string'!=typeof a)for(var e in a)b.d(d,e,function(b){return a[b]}.bind(null,e));return d},b.n=function(a){var c=a&&a.__esModule?function(){return a['default']}:function(){return a};return b.d(c,'a',c),c},b.o=function(a,b){return Object.prototype.hasOwnProperty.call(a,b)},b.p='/css',b(b.s=0)})({"./Scripts/index.js":/*!**************************!*\
  !*** ./Scripts/index.js ***!
  \**************************//*! no static exports found */function(module,exports,__webpack_require__){'use strict';eval('\n\nvar _helpers = __webpack_require__(/*! ./shared/helpers */ "./Scripts/shared/helpers.js");\n\nvar thisIsAConstant = (0, _helpers.justATest)();\nconsole.log("just a test outputs: " + thisIsAConstant);\n\n//# sourceURL=webpack:///./Scripts/index.js?')},"./Scripts/shared/helpers.js":/*!***********************************!*\
  !*** ./Scripts/shared/helpers.js ***!
  \***********************************//*! no static exports found */function(module,exports,__webpack_require__){'use strict';eval('\n\nexports.__esModule = true;\nexports.justATest = justATest;\n\n//just a sample js file to test the bundling and minification. TODO: replace with something real\nfunction justATest() {\n  return 1;\n}\n\n//# sourceURL=webpack:///./Scripts/shared/helpers.js?')},0:/*!********************************!*\
  !*** multi ./Scripts/index.js ***!
  \********************************//*! no static exports found */function(module,exports,__webpack_require__){eval('module.exports = __webpack_require__(/*! ./Scripts/index.js */"./Scripts/index.js");\n\n\n//# sourceURL=webpack:///multi_./Scripts/index.js?')}});