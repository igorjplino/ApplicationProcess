"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ApplicantController = void 0;
const index_1 = require("../services/index");
const index_2 = require("../models/index");
class ApplicantController {
    constructor() {
        this._service = new index_1.ApplicantService();
        this._saveBtn = $(".form").submit(this.Save_Click.bind(this));
        this._name = $("#name");
    }
    Save_Click(e) {
        e.preventDefault();
        this.ToEntity();
        this._service.Save(this._applicant);
    }
    ToEntity() {
        this._applicant = new index_2.Applicant("Igor Jorge", "Pontes Lino", "Rua da Motivação", "Brazil", "igor@mail.com", 30, false);
    }
}
exports.ApplicantController = ApplicantController;
//# sourceMappingURL=ApplicantController.js.map