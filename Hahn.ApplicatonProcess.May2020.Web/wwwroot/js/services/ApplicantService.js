"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ApplicantService = void 0;
const BaseService_1 = require("./BaseService");
class ApplicantService extends BaseService_1.BaseService {
    constructor() {
        super(...arguments);
        this.url = "https://localhost:44356";
    }
    Save(applicant) {
        return fetch(`${this.url}/api/applicant/`, {
            method: "POST",
            body: JSON.stringify(applicant)
        })
            .then(res => this.IsOk(res))
            .then(res => res.json())
            .catch(err => console.log(err));
    }
    Get(id) {
        return __awaiter(this, void 0, void 0, function* () {
            return fetch(`${this.url}/api/applicant/${1}`)
                .then(res => this.IsOk(res))
                .then(res => res.json())
                .then((dado) => dado);
        });
    }
}
exports.ApplicantService = ApplicantService;
//# sourceMappingURL=ApplicantService.js.map