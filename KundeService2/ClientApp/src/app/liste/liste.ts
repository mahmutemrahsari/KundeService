import { Component, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Faq } from "../Faq";

@Component({
  templateUrl: "liste.html"
})
export class Liste {
  alleFaqer: Array<Faq>;
  laster: boolean;


  constructor(private http: HttpClient, private router: Router, private modalService: NgbModal) { }

  ngOnInit() {
    this.laster = true;
    this.hentAlleKunder();
  }

  hentAlleKunder() {
    this.http.get<Faq[]>("api/faq/")
      .subscribe(faqene => {
        this.alleFaqer = faqene;
        this.laster = false;
      },
       error => console.log(error)
      );
  };

}
