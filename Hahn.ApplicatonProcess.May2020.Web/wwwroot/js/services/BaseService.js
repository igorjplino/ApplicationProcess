"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
class BaseService {
    IsOk(res) {
        if (res.ok) {
            return res;
        }
        else {
            throw new Error(res.statusText);
        }
    }
}
exports.BaseService = BaseService;
//# sourceMappingURL=BaseService.js.map