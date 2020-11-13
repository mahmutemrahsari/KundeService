import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { Faq } from "../Faq";

@Component({
  templateUrl: "lagre.html"
})
export class Lagre {
  skjema: FormGroup;
  
  validering = {
    id: [""],
    question: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])
    ],
    answer: [
      null, Validators.compose([Validators.required, Validators.pattern("[a-zA-ZøæåØÆÅ\\-. ]{2,30}")])
    ]
  }

  constructor(private http: HttpClient, private fb: FormBuilder, private router: Router) {
    this.skjema = fb.group(this.validering);
  }

  vedSubmit() {
      this.lagreFaq();
  }

  lagreFaq() {
    const lagretFaq = new Faq();

    lagretFaq.question = this.skjema.value.question;
    lagretFaq.answer = this.skjema.value.answer;
   
    this.http.post("api/faq", lagretFaq)
      .subscribe(retur => {
        this.router.navigate(['/liste']);
      },
       error => console.log(error)
      );
  };
}
