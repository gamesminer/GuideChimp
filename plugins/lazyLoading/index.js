/**
 * Copyright (C) 2020 Labs64 GmbH
 *
 * This source code is licensed under the European Union Public License, version 1.2
 * located in the LICENSE file
 */

/**
 *
 * @param {Class} cls GuideChimp class
 * @param {Object} factory GuideChimp factory
 * @param {Object} options the options object
 */
module.exports = (cls, factory, options) => {
    const opt = options || {};

    let { timeout = 5000 } = opt;
    const { frequency = 100 } = opt;

    const parentInit = cls.prototype.init;

    // eslint-disable-next-line func-names,no-param-reassign
    cls.prototype.init = function () {
        parentInit.call(this);

        this.on('onBeforeChange', (toStep) => new Promise((resolve) => {
            const { element } = toStep;

            if (!element) {
                resolve();
                return;
            }

            const checkElementExists = () => {
                const el = this.getStepElement(toStep, true);
                const defaultEl = this.findDefaultElement();
                return (el && el !== defaultEl);
            };

            if (checkElementExists()) {
                resolve();
                return;
            }

            const interval = setInterval(() => {
                timeout -= frequency;
                if (checkElementExists() || timeout <= 0) {
                    clearInterval(interval);
                    resolve();
                }
            }, frequency);
        }));
    };
};
