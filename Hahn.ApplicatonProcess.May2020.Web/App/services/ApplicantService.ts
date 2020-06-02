import { Applicant } from "../models/index";
import { BaseService } from "./BaseService";

export class ApplicantService extends BaseService {

    private readonly url: string = "https://localhost:44356";

    public Save(applicant: Applicant): Promise<void> {

        return fetch(`${this.url}/api/applicant/`, {
                method: "POST",
                body: JSON.stringify(applicant)
        })
        .then(res => this.IsOk(res))
        .then(res => res.json())
        .catch(err => console.log(err));
    }

    public async Get(id: number): Promise<Applicant> {

        return fetch(`${this.url}/api/applicant/${1}`)
            .then(res => this.IsOk(res))
            .then(res => res.json())
            .then((dado: Applicant) => dado);
    }
}