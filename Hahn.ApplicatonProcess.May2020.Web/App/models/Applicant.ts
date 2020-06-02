
export class Applicant {

    private _ID: number;

    constructor (
        readonly Name: string,
         readonly FamilyName: string,
         readonly Address: string,
         readonly CountryOfOrigin: string,
         readonly EmailAddress: string,
         readonly Age: number,
         readonly Hired: boolean,
    )
    { }
}