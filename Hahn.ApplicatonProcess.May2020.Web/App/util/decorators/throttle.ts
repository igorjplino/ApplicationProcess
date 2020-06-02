
export function throttle(milisegundos = 500) {

    return function (descriptor: PropertyDescriptor) {

        const metodoOriginal = descriptor.value;
        let timer = 0;

        descriptor.value = function (...args: any[]) {

            if (event) {
                event.preventDefault();
            }

            clearInterval(timer);
            timer = setTimeout(() => metodoOriginal.apply(this, args), milisegundos);
        }

        return descriptor;
    };
}