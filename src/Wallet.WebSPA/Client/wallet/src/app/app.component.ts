import {Component} from '@angular/core';
import {DomSanitizer} from "@angular/platform-browser";
import {MatIconRegistry} from "@angular/material";
import {AuthService} from "./auth.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private matIconRegistry: MatIconRegistry,
              private domSanitizer: DomSanitizer,
              auth: AuthService) {
    this.IconsConfiglet(matIconRegistry, domSanitizer);
    this.loggedin = auth.isLoggedIn();
    auth.loggedIn.subscribe(() => {
      this.loggedin = auth.isLoggedIn();
    });
  }

  title = 'wallet';
  loggedin: boolean;

  IconsConfiglet(matIconRegistry, domSanitizer) {
    matIconRegistry.addSvgIcon(
      `logo`,
      domSanitizer.bypassSecurityTrustResourceUrl("../assets/Logo-colored.svg")
    );
    matIconRegistry.addSvgIcon(
      `logo-mini`,
      domSanitizer.bypassSecurityTrustResourceUrl("../assets/Logo-colored-mini.svg")
    );
  };
}
