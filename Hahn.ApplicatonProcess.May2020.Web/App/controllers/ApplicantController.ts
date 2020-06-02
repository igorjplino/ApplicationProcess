import { ApplicantService } from '../services/index';
import { Applicant } from '../models/index';
import { throttle } from '../util/decorators/index';

export class ApplicantController {

    private _applicant: Applicant;

    private _name: JQuery;

    private _saveBtn: JQuery;

    private _service = new ApplicantService();

    constructor(){

        this._saveBtn = $(".form").submit(this.Save_Click.bind(this));

        this._name = $("#name");
    }

    //@throttle()
    public Save_Click(e: Event): void {

        e.preventDefault();

        this.ToEntity();   

        this._service.Save(this._applicant);
    }

    private ToEntity(): void {

        this._applicant = new Applicant(
            "Igor Jorge",
            "Pontes Lino",
            "Rua da Motivação",
            "Brazil",
            "igor@mail.com",
            30,
            false
        )
    }
}