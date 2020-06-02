

export class BaseService {

    protected IsOk(res: Response): Response {

        if (res.ok) {
            return res;
        }
        else {
            throw new Error(res.statusText);
        }
    }
}