import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class AuthService {

    constructor() {}

    isLoggedIn () {
        var google_token = localStorage.getItem ('google_auth');
        if (google_token == null) return false;

        return true;
    }
}  