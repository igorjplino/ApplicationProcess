"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function throttle(milisegundos = 500) {
    return function (descriptor) {
        const metodoOriginal = descriptor.value;
        let timer = 0;
        descriptor.value = function (...args) {
            if (event) {
                event.preventDefault();
            }
            clearInterval(timer);
            timer = setTimeout(() => metodoOriginal.apply(this, args), milisegundos);
        };
        return descriptor;
    };
}
exports.throttle = throttle;
//# sourceMappingURL=throttle.js.map