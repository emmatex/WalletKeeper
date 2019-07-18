(window.webpackJsonp=window.webpackJsonp||[]).push([[1],{0:function(t,n,c){t.exports=c("zUnb")},"5BDf":function(t,n){t.exports='<h1 mat-dialog-title>Edit account</h1>\n<div mat-dialog-content>\n  <form class="form" #accountForm="ngForm">\n    <mat-form-field >\n      <input matInput type="text" name="title" [(ngModel)]="title" placeholder="Account name" required>\n    </mat-form-field>\n  </form>\n</div>\n<mat-dialog-actions align="end">\n  <button mat-button [mat-dialog-close]="null">Cancel</button>\n  <button mat-button (click)="save()" cdkFocusInitial color="primary" [disabled]="busy||!accountForm.valid">Save</button>\n</mat-dialog-actions>\n'},"7R3X":function(t,n){t.exports="<p>Home page.</p>\n"},Gf7b:function(t,n){t.exports='<h1 mat-dialog-title>Create a new account</h1>\n<div mat-dialog-content>\n  <form class="form" #accountForm="ngForm">\n    <mat-form-field >\n      <input matInput type="text" name="title" [(ngModel)]="title" placeholder="Account name" required>\n    </mat-form-field>\n    <mat-form-field >\n      <mat-label>Account type</mat-label>\n      <mat-select [(value)]="selectedType" required>\n        <mat-option *ngFor="let type of types" [value]="type.id">\n          {{type.title}}\n        </mat-option>\n      </mat-select>\n    </mat-form-field>\n  </form>\n</div>\n<mat-dialog-actions align="end">\n  <button mat-button [mat-dialog-close]="null">Cancel</button>\n  <button mat-button (click)="save()" cdkFocusInitial color="primary" [disabled]="busy||!accountForm.valid">Save</button>\n</mat-dialog-actions>\n'},"M+Fk":function(t,n){t.exports='<div class="sidebar">\n  <button mat-button routerLink="/home" routerLinkActive="active">Home</button>\n  <button mat-button routerLink="/accounts"  routerLinkActive="active">Accounts</button>\n</div>\n'},U0zd:function(t,n){t.exports=".account-component-container {\n  -webkit-box-flex: 1;\n          flex-grow: 1;\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n          flex-direction: column;\n}\n.account-component-container .add-button-container {\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n          flex-direction: row;\n  -webkit-box-align: center;\n          align-items: center;\n  border-top-right-radius: 4px;\n  box-shadow: 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12);\n  height: 48px;\n}\n.account-component-container .add-button-container button {\n  margin-left: 5px;\n}\n.account-component-container .accounts-list {\n  -webkit-box-flex: 1;\n          flex-grow: 1;\n}\n.account-component-container .accounts-list .account-list-item mat-panel-title {\n  width: 300px;\n  -webkit-box-flex: initial;\n          flex-grow: initial;\n}\n.account-component-container .accounts-list .account-list-item:first-child {\n  border-radius: 0;\n}\n.account-component-container .fas {\n  color: #264653;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvYWNjb3VudHMvQzpcXFJlcG9zXFxXYWxsZXRLZWVwZXJcXHNyY1xcV2FsbGV0LldlYlNQQVxcQ2xpZW50XFx3YWxsZXQvc3JjXFxhcHBcXGFjY291bnRzXFxhY2NvdW50cy5jb21wb25lbnQuc2NzcyIsInNyYy9hcHAvYWNjb3VudHMvYWNjb3VudHMuY29tcG9uZW50LnNjc3MiLCJzcmMvYXBwL2FjY291bnRzL0M6XFxSZXBvc1xcV2FsbGV0S2VlcGVyXFxzcmNcXFdhbGxldC5XZWJTUEFcXENsaWVudFxcd2FsbGV0L3NyY1xcY29tbW9uLnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBRUE7RUFDRSxtQkFBQTtVQUFBLFlBQUE7RUFDQSxvQkFBQTtFQUFBLGFBQUE7RUFDQSw0QkFBQTtFQUFBLDZCQUFBO1VBQUEsc0JBQUE7QUNERjtBREdFO0VBQ0Usb0JBQUE7RUFBQSxhQUFBO0VBQ0EsOEJBQUE7RUFBQSw2QkFBQTtVQUFBLG1CQUFBO0VBQ0EseUJBQUE7VUFBQSxtQkFBQTtFQUNBLDRCQUFBO0VBQ0EseUhBQUE7RUFDQSxZQUFBO0FDREo7QURFSTtFQUNFLGdCQUFBO0FDQU47QURJRTtFQUNFLG1CQUFBO1VBQUEsWUFBQTtBQ0ZKO0FES007RUFDRSxZQUFBO0VBQ0EseUJBQUE7VUFBQSxrQkFBQTtBQ0hSO0FES007RUFDRSxnQkFBQTtBQ0hSO0FET0U7RUFDRSxjRWhDVztBRDJCZiIsImZpbGUiOiJzcmMvYXBwL2FjY291bnRzL2FjY291bnRzLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiQGltcG9ydCAnLi4vLi4vY29tbW9uJztcclxuXHJcbi5hY2NvdW50LWNvbXBvbmVudC1jb250YWluZXIge1xyXG4gIGZsZXgtZ3JvdzogMTtcclxuICBkaXNwbGF5OiBmbGV4O1xyXG4gIGZsZXgtZGlyZWN0aW9uOiBjb2x1bW47XHJcblxyXG4gIC5hZGQtYnV0dG9uLWNvbnRhaW5lciB7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG4gICAgZmxleC1kaXJlY3Rpb246IHJvdztcclxuICAgIGFsaWduLWl0ZW1zOiBjZW50ZXI7XHJcbiAgICBib3JkZXItdG9wLXJpZ2h0LXJhZGl1czogNHB4O1xyXG4gICAgYm94LXNoYWRvdzogMHB4IDNweCAxcHggLTJweCByZ2JhKDAsIDAsIDAsIDAuMiksIDBweCAycHggMnB4IDBweCByZ2JhKDAsIDAsIDAsIDAuMTQpLCAwcHggMXB4IDVweCAwcHggcmdiYSgwLCAwLCAwLCAwLjEyKTtcclxuICAgIGhlaWdodDogNDhweDtcclxuICAgIGJ1dHRvbntcclxuICAgICAgbWFyZ2luLWxlZnQ6IDVweDtcclxuICAgIH1cclxuICB9XHJcblxyXG4gIC5hY2NvdW50cy1saXN0IHtcclxuICAgIGZsZXgtZ3JvdzogMTtcclxuXHJcbiAgICAuYWNjb3VudC1saXN0LWl0ZW0ge1xyXG4gICAgICBtYXQtcGFuZWwtdGl0bGUge1xyXG4gICAgICAgIHdpZHRoOiAzMDBweDtcclxuICAgICAgICBmbGV4LWdyb3c6IGluaXRpYWw7XHJcbiAgICAgIH1cclxuICAgICAgJjpmaXJzdC1jaGlsZHtcclxuICAgICAgICBib3JkZXItcmFkaXVzOiAwO1xyXG4gICAgICB9XHJcbiAgICB9XHJcbiAgfVxyXG4gIC5mYXN7XHJcbiAgICBjb2xvcjokcHJpbWFyeS1jb2xvclxyXG4gIH1cclxufVxyXG4iLCIuYWNjb3VudC1jb21wb25lbnQtY29udGFpbmVyIHtcbiAgZmxleC1ncm93OiAxO1xuICBkaXNwbGF5OiBmbGV4O1xuICBmbGV4LWRpcmVjdGlvbjogY29sdW1uO1xufVxuLmFjY291bnQtY29tcG9uZW50LWNvbnRhaW5lciAuYWRkLWJ1dHRvbi1jb250YWluZXIge1xuICBkaXNwbGF5OiBmbGV4O1xuICBmbGV4LWRpcmVjdGlvbjogcm93O1xuICBhbGlnbi1pdGVtczogY2VudGVyO1xuICBib3JkZXItdG9wLXJpZ2h0LXJhZGl1czogNHB4O1xuICBib3gtc2hhZG93OiAwcHggM3B4IDFweCAtMnB4IHJnYmEoMCwgMCwgMCwgMC4yKSwgMHB4IDJweCAycHggMHB4IHJnYmEoMCwgMCwgMCwgMC4xNCksIDBweCAxcHggNXB4IDBweCByZ2JhKDAsIDAsIDAsIDAuMTIpO1xuICBoZWlnaHQ6IDQ4cHg7XG59XG4uYWNjb3VudC1jb21wb25lbnQtY29udGFpbmVyIC5hZGQtYnV0dG9uLWNvbnRhaW5lciBidXR0b24ge1xuICBtYXJnaW4tbGVmdDogNXB4O1xufVxuLmFjY291bnQtY29tcG9uZW50LWNvbnRhaW5lciAuYWNjb3VudHMtbGlzdCB7XG4gIGZsZXgtZ3JvdzogMTtcbn1cbi5hY2NvdW50LWNvbXBvbmVudC1jb250YWluZXIgLmFjY291bnRzLWxpc3QgLmFjY291bnQtbGlzdC1pdGVtIG1hdC1wYW5lbC10aXRsZSB7XG4gIHdpZHRoOiAzMDBweDtcbiAgZmxleC1ncm93OiBpbml0aWFsO1xufVxuLmFjY291bnQtY29tcG9uZW50LWNvbnRhaW5lciAuYWNjb3VudHMtbGlzdCAuYWNjb3VudC1saXN0LWl0ZW06Zmlyc3QtY2hpbGQge1xuICBib3JkZXItcmFkaXVzOiAwO1xufVxuLmFjY291bnQtY29tcG9uZW50LWNvbnRhaW5lciAuZmFzIHtcbiAgY29sb3I6ICMyNjQ2NTM7XG59IiwiJGZvbnQtY29sb3I6IzVmNjM2ODtcclxuJHByaW1hcnktY29sb3I6IzI2NDY1MztcclxuIl19 */"},UaI1:function(t,n){t.exports=".sidebar {\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n          flex-direction: column;\n  -webkit-box-flex: 1;\n          flex-grow: 1;\n  width: 160px;\n  padding-right: 20px;\n  padding-top: 10px;\n}\n.sidebar button {\n  text-align: left;\n  border-radius: 0 66px 66px 0;\n}\n.sidebar button.active {\n  color: #264653;\n  background-color: #c6dce5;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvc2lkZWJhci9DOlxcUmVwb3NcXFdhbGxldEtlZXBlclxcc3JjXFxXYWxsZXQuV2ViU1BBXFxDbGllbnRcXHdhbGxldC9zcmNcXGFwcFxcc2lkZWJhclxcc2lkZWJhci5jb21wb25lbnQuc2NzcyIsInNyYy9hcHAvc2lkZWJhci9zaWRlYmFyLmNvbXBvbmVudC5zY3NzIiwic3JjL2FwcC9zaWRlYmFyL0M6XFxSZXBvc1xcV2FsbGV0S2VlcGVyXFxzcmNcXFdhbGxldC5XZWJTUEFcXENsaWVudFxcd2FsbGV0L3NyY1xcY29tbW9uLnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQ0E7RUFDRSxvQkFBQTtFQUFBLGFBQUE7RUFDQSw0QkFBQTtFQUFBLDZCQUFBO1VBQUEsc0JBQUE7RUFDQSxtQkFBQTtVQUFBLFlBQUE7RUFDQSxZQUFBO0VBQ0EsbUJBQUE7RUFDQSxpQkFBQTtBQ0FGO0FEQ0U7RUFDRSxnQkFBQTtFQUNBLDRCQUFBO0FDQ0o7QURBSTtFQUNFLGNFWFM7RUZZVCx5QkFBQTtBQ0VOIiwiZmlsZSI6InNyYy9hcHAvc2lkZWJhci9zaWRlYmFyLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiQGltcG9ydCAnLi4vLi4vY29tbW9uJztcclxuLnNpZGViYXJ7XHJcbiAgZGlzcGxheTogZmxleDtcclxuICBmbGV4LWRpcmVjdGlvbjogY29sdW1uO1xyXG4gIGZsZXgtZ3JvdzogMTtcclxuICB3aWR0aDogMTYwcHg7XHJcbiAgcGFkZGluZy1yaWdodDogMjBweDtcclxuICBwYWRkaW5nLXRvcDogMTBweDtcclxuICBidXR0b257XHJcbiAgICB0ZXh0LWFsaWduOiBsZWZ0O1xyXG4gICAgYm9yZGVyLXJhZGl1czogMCA2NnB4IDY2cHggMDtcclxuICAgICYuYWN0aXZle1xyXG4gICAgICBjb2xvcjokcHJpbWFyeS1jb2xvcjtcclxuICAgICAgYmFja2dyb3VuZC1jb2xvcjogbGlnaHRlbigkcHJpbWFyeS1jb2xvciw2MCk7XHJcbiAgICB9XHJcbiAgfVxyXG59XHJcbiIsIi5zaWRlYmFyIHtcbiAgZGlzcGxheTogZmxleDtcbiAgZmxleC1kaXJlY3Rpb246IGNvbHVtbjtcbiAgZmxleC1ncm93OiAxO1xuICB3aWR0aDogMTYwcHg7XG4gIHBhZGRpbmctcmlnaHQ6IDIwcHg7XG4gIHBhZGRpbmctdG9wOiAxMHB4O1xufVxuLnNpZGViYXIgYnV0dG9uIHtcbiAgdGV4dC1hbGlnbjogbGVmdDtcbiAgYm9yZGVyLXJhZGl1czogMCA2NnB4IDY2cHggMDtcbn1cbi5zaWRlYmFyIGJ1dHRvbi5hY3RpdmUge1xuICBjb2xvcjogIzI2NDY1MztcbiAgYmFja2dyb3VuZC1jb2xvcjogI2M2ZGNlNTtcbn0iLCIkZm9udC1jb2xvcjojNWY2MzY4O1xyXG4kcHJpbWFyeS1jb2xvcjojMjY0NjUzO1xyXG4iXX0= */"},ZTFi:function(t,n){t.exports=".login-container {\n  border-radius: 10px;\n  border: 1px solid #bdbdbd;\n  width: 800px;\n  height: 350px;\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n          flex-direction: column;\n}\n.login-container mat-progress-bar {\n  border-radius: 30px 30px 0 0;\n  height: 7px;\n}\n.login-container .login-form-container {\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n          flex-direction: row;\n  -webkit-box-align: center;\n          align-items: center;\n  -webkit-box-flex: 1;\n          flex-grow: 1;\n  padding: 0 20px;\n}\n.login-container .logo {\n  height: 250px;\n  margin-left: 25px;\n}\n.login-container .login-form {\n  justify-self: center;\n  align-self: center;\n  -webkit-box-flex: 1;\n          flex-grow: 1;\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n          flex-direction: column;\n  -webkit-box-align: center;\n          align-items: center;\n}\n.login-container .login-form mat-form-field {\n  width: 250px;\n}\n.login-container .login-form button {\n  width: 250px;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvbG9naW4vQzpcXFJlcG9zXFxXYWxsZXRLZWVwZXJcXHNyY1xcV2FsbGV0LldlYlNQQVxcQ2xpZW50XFx3YWxsZXQvc3JjXFxhcHBcXGxvZ2luXFxsb2dpbi5jb21wb25lbnQuc2NzcyIsInNyYy9hcHAvbG9naW4vbG9naW4uY29tcG9uZW50LnNjc3MiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7RUFtQkUsbUJBQUE7RUFDQSx5QkFBQTtFQUNBLFlBQUE7RUFDQSxhQUFBO0VBQ0Esb0JBQUE7RUFBQSxhQUFBO0VBQ0EsNEJBQUE7RUFBQSw2QkFBQTtVQUFBLHNCQUFBO0FDakJGO0FERkU7RUFDRSw0QkFBQTtFQUNBLFdBQUE7QUNJSjtBRERFO0VBQ0Usb0JBQUE7RUFBQSxhQUFBO0VBQ0EsOEJBQUE7RUFBQSw2QkFBQTtVQUFBLG1CQUFBO0VBQ0EseUJBQUE7VUFBQSxtQkFBQTtFQUNBLG1CQUFBO1VBQUEsWUFBQTtFQUNBLGVBQUE7QUNHSjtBRFFFO0VBQ0UsYUFBQTtFQUNBLGlCQUFBO0FDTko7QURTRTtFQUNFLG9CQUFBO0VBQ0Esa0JBQUE7RUFDQSxtQkFBQTtVQUFBLFlBQUE7RUFDQSxvQkFBQTtFQUFBLGFBQUE7RUFDQSw0QkFBQTtFQUFBLDZCQUFBO1VBQUEsc0JBQUE7RUFDQSx5QkFBQTtVQUFBLG1CQUFBO0FDUEo7QURTSTtFQUNFLFlBQUE7QUNQTjtBRFVJO0VBQ0UsWUFBQTtBQ1JOIiwiZmlsZSI6InNyYy9hcHAvbG9naW4vbG9naW4uY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIubG9naW4tY29udGFpbmVyIHtcclxuICAucHJvZ3Jlc3MtY29udGFpbmVyIHtcclxuXHJcbiAgfVxyXG5cclxuICBtYXQtcHJvZ3Jlc3MtYmFyIHtcclxuICAgIGJvcmRlci1yYWRpdXM6IDMwcHggMzBweCAwIDA7XHJcbiAgICBoZWlnaHQ6IDdweDtcclxuICB9XHJcblxyXG4gIC5sb2dpbi1mb3JtLWNvbnRhaW5lciB7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG4gICAgZmxleC1kaXJlY3Rpb246IHJvdztcclxuICAgIGFsaWduLWl0ZW1zOiBjZW50ZXI7XHJcbiAgICBmbGV4LWdyb3c6IDE7XHJcbiAgICBwYWRkaW5nOiAwIDIwcHg7XHJcblxyXG4gIH1cclxuXHJcbiAgYm9yZGVyLXJhZGl1czogMTBweDtcclxuICBib3JkZXI6IDFweCBzb2xpZCAjYmRiZGJkO1xyXG4gIHdpZHRoOiA4MDBweDtcclxuICBoZWlnaHQ6IDM1MHB4O1xyXG4gIGRpc3BsYXk6IGZsZXg7XHJcbiAgZmxleC1kaXJlY3Rpb246IGNvbHVtbjtcclxuXHJcbiAgLmxvZ28ge1xyXG4gICAgaGVpZ2h0OiAyNTBweDtcclxuICAgIG1hcmdpbi1sZWZ0OiAyNXB4O1xyXG4gIH1cclxuXHJcbiAgLmxvZ2luLWZvcm0ge1xyXG4gICAganVzdGlmeS1zZWxmOiBjZW50ZXI7XHJcbiAgICBhbGlnbi1zZWxmOiBjZW50ZXI7XHJcbiAgICBmbGV4LWdyb3c6IDE7XHJcbiAgICBkaXNwbGF5OiBmbGV4O1xyXG4gICAgZmxleC1kaXJlY3Rpb246IGNvbHVtbjtcclxuICAgIGFsaWduLWl0ZW1zOiBjZW50ZXI7XHJcblxyXG4gICAgbWF0LWZvcm0tZmllbGQge1xyXG4gICAgICB3aWR0aDogMjUwcHg7XHJcbiAgICB9XHJcblxyXG4gICAgYnV0dG9uIHtcclxuICAgICAgd2lkdGg6IDI1MHB4O1xyXG4gICAgfVxyXG4gIH1cclxufVxyXG4iLCIubG9naW4tY29udGFpbmVyIHtcbiAgYm9yZGVyLXJhZGl1czogMTBweDtcbiAgYm9yZGVyOiAxcHggc29saWQgI2JkYmRiZDtcbiAgd2lkdGg6IDgwMHB4O1xuICBoZWlnaHQ6IDM1MHB4O1xuICBkaXNwbGF5OiBmbGV4O1xuICBmbGV4LWRpcmVjdGlvbjogY29sdW1uO1xufVxuLmxvZ2luLWNvbnRhaW5lciBtYXQtcHJvZ3Jlc3MtYmFyIHtcbiAgYm9yZGVyLXJhZGl1czogMzBweCAzMHB4IDAgMDtcbiAgaGVpZ2h0OiA3cHg7XG59XG4ubG9naW4tY29udGFpbmVyIC5sb2dpbi1mb3JtLWNvbnRhaW5lciB7XG4gIGRpc3BsYXk6IGZsZXg7XG4gIGZsZXgtZGlyZWN0aW9uOiByb3c7XG4gIGFsaWduLWl0ZW1zOiBjZW50ZXI7XG4gIGZsZXgtZ3JvdzogMTtcbiAgcGFkZGluZzogMCAyMHB4O1xufVxuLmxvZ2luLWNvbnRhaW5lciAubG9nbyB7XG4gIGhlaWdodDogMjUwcHg7XG4gIG1hcmdpbi1sZWZ0OiAyNXB4O1xufVxuLmxvZ2luLWNvbnRhaW5lciAubG9naW4tZm9ybSB7XG4gIGp1c3RpZnktc2VsZjogY2VudGVyO1xuICBhbGlnbi1zZWxmOiBjZW50ZXI7XG4gIGZsZXgtZ3JvdzogMTtcbiAgZGlzcGxheTogZmxleDtcbiAgZmxleC1kaXJlY3Rpb246IGNvbHVtbjtcbiAgYWxpZ24taXRlbXM6IGNlbnRlcjtcbn1cbi5sb2dpbi1jb250YWluZXIgLmxvZ2luLWZvcm0gbWF0LWZvcm0tZmllbGQge1xuICB3aWR0aDogMjUwcHg7XG59XG4ubG9naW4tY29udGFpbmVyIC5sb2dpbi1mb3JtIGJ1dHRvbiB7XG4gIHdpZHRoOiAyNTBweDtcbn0iXX0= */"},bdh1:function(t,n){t.exports="\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2hvbWUvaG9tZS5jb21wb25lbnQuc2NzcyJ9 */"},eekT:function(t,n){t.exports="form {\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: vertical;\n  -webkit-box-direction: normal;\n          flex-direction: column;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvYWNjb3VudHMvY3JlYXRlLWFjY291bnQvQzpcXFJlcG9zXFxXYWxsZXRLZWVwZXJcXHNyY1xcV2FsbGV0LldlYlNQQVxcQ2xpZW50XFx3YWxsZXQvc3JjXFxhcHBcXGFjY291bnRzXFxjcmVhdGUtYWNjb3VudFxcY3JlYXRlLWFjY291bnQuY29tcG9uZW50LnNjc3MiLCJzcmMvYXBwL2FjY291bnRzL2NyZWF0ZS1hY2NvdW50L2NyZWF0ZS1hY2NvdW50LmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0Usb0JBQUE7RUFBQSxhQUFBO0VBQ0EsNEJBQUE7RUFBQSw2QkFBQTtVQUFBLHNCQUFBO0FDQ0YiLCJmaWxlIjoic3JjL2FwcC9hY2NvdW50cy9jcmVhdGUtYWNjb3VudC9jcmVhdGUtYWNjb3VudC5jb21wb25lbnQuc2NzcyIsInNvdXJjZXNDb250ZW50IjpbImZvcm17XHJcbiAgZGlzcGxheTogZmxleDtcclxuICBmbGV4LWRpcmVjdGlvbjogY29sdW1uO1xyXG59XHJcbiIsImZvcm0ge1xuICBkaXNwbGF5OiBmbGV4O1xuICBmbGV4LWRpcmVjdGlvbjogY29sdW1uO1xufSJdfQ== */"},haLy:function(t,n){t.exports="\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IiIsImZpbGUiOiJzcmMvYXBwL2FjY291bnRzL2VkaXQtYWNjb3VudC9lZGl0LWFjY291bnQuY29tcG9uZW50LnNjc3MifQ== */"},"k6/D":function(t,n){t.exports='<div class="account-component-container">\n  <mat-progress-bar mode="indeterminate" [ngClass]="{\'hidden\':!busy}"></mat-progress-bar>\n  <div class="add-button-container">\n    <button mat-button (click)="createAccount()"> <span><i class="fas fa-plus"></i> Create new account</span></button>\n  </div>\n  <mat-accordion class="accounts-list">\n    <mat-expansion-panel class="account-list-item"  *ngFor="let account of accounts">\n      <mat-expansion-panel-header>\n        <mat-panel-title>\n          {{account.title}}\n        </mat-panel-title>\n        <mat-panel-description>\n          {{account.accountTypeTitle}}\n        </mat-panel-description>\n      </mat-expansion-panel-header>\n      <p></p>\n      <mat-action-row>\n        <button mat-icon-button (click)="edit(account)"><i class="fas fa-edit"></i></button>\n        <button mat-icon-button><i class="fas fa-trash"></i></button>\n      </mat-action-row>\n    </mat-expansion-panel>\n  </mat-accordion>\n</div>\n'},lILz:function(t,n){t.exports='<app-toolbar *ngIf="loggedin"></app-toolbar>\n<div class="app-container">\n  <app-sidebar *ngIf="loggedin"></app-sidebar>\n  <div class="current-component-container">\n    <router-outlet></router-outlet>\n  </div>\n</div>\n'},okTi:function(t,n){t.exports='<mat-toolbar class="toolbar">\n  <mat-icon svgIcon="logo-mini" class="brand-logo"></mat-icon>\n  <div class="search-container">\n    <i class="fas fa-search"></i>\n    <form class="search-form">\n        <input  placeholder="Search">\n    </form>\n  </div>\n  <div class="fill"></div>\n  <button mat-icon-button class="user-button" [matMenuTriggerFor]="userMenu" a><i class="fas fa-user"></i></button>\n  <mat-menu #userMenu="matMenu">\n    <button mat-menu-item>Settings</button>\n    <button mat-menu-item (click)="logout()">Logout</button>\n  </mat-menu>\n</mat-toolbar>\n'},rkYV:function(t,n){t.exports='<div class="login-container">\r\n  <div class="progress-container">\r\n    <mat-progress-bar mode="indeterminate" [ngClass]="{\'hidden\':!busy}"></mat-progress-bar>\r\n\r\n  </div>\r\n  <div class="login-form-container">\r\n    <img class="logo" src="/assets/Logo-colored.png">\r\n    <form class="login-form" #loginForm="ngForm">\r\n      <mat-form-field class="login-username">\r\n        <input matInput name="username" placeholder="Username" [(ngModel)]="username">\r\n      </mat-form-field>\r\n      <mat-form-field class="login-password">\r\n        <input matInput name="password" placeholder="Password" type="password" [(ngModel)]="password">\r\n      </mat-form-field>\r\n      <button mat-raised-button color="primary" (click)="login()" [disabled]="busy || !loginForm.valid">Login</button>\r\n      <p class="error">{{message}}</p>\r\n    </form>\r\n  </div>\r\n</div>\r\n'},uiS6:function(t,n){t.exports=".toolbar {\n  background-color: white;\n  border-bottom: 1px solid rgba(0, 0, 0, 0.2);\n}\n.toolbar .user-button {\n  background-color: #f7f7f7;\n}\n.toolbar .user-button .fas {\n  font-size: 22px;\n}\n.toolbar .brand-logo {\n  height: 80px;\n  width: 80px;\n}\n.toolbar .search-container {\n  margin-left: 85px;\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n          flex-direction: row;\n  -webkit-box-align: center;\n          align-items: center;\n  background-color: #f7f7f7;\n  border-radius: 4px;\n}\n.toolbar .search-container .fas {\n  margin: 0 10px;\n}\n.toolbar .search-container input {\n  height: 40px;\n  width: 400px;\n  background-color: transparent;\n  border: 0;\n  outline-width: 0;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvdG9vbGJhci9DOlxcUmVwb3NcXFdhbGxldEtlZXBlclxcc3JjXFxXYWxsZXQuV2ViU1BBXFxDbGllbnRcXHdhbGxldC9zcmNcXGFwcFxcdG9vbGJhclxcdG9vbGJhci5jb21wb25lbnQuc2NzcyIsInNyYy9hcHAvdG9vbGJhci90b29sYmFyLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUFBO0VBQ0UsdUJBQUE7RUFDQSwyQ0FBQTtBQ0NGO0FEQUU7RUFDRSx5QkFBQTtBQ0VKO0FEREk7RUFDRSxlQUFBO0FDR047QURBRTtFQUNFLFlBQUE7RUFDQSxXQUFBO0FDRUo7QURDRTtFQUNFLGlCQUFBO0VBQ0Esb0JBQUE7RUFBQSxhQUFBO0VBQ0EsOEJBQUE7RUFBQSw2QkFBQTtVQUFBLG1CQUFBO0VBQ0EseUJBQUE7VUFBQSxtQkFBQTtFQUNBLHlCQUFBO0VBQ0Esa0JBQUE7QUNDSjtBRENJO0VBQ0UsY0FBQTtBQ0NOO0FERUk7RUFDRSxZQUFBO0VBQ0EsWUFBQTtFQUNBLDZCQUFBO0VBQ0EsU0FBQTtFQUNBLGdCQUFBO0FDQU4iLCJmaWxlIjoic3JjL2FwcC90b29sYmFyL3Rvb2xiYXIuY29tcG9uZW50LnNjc3MiLCJzb3VyY2VzQ29udGVudCI6WyIudG9vbGJhciB7XHJcbiAgYmFja2dyb3VuZC1jb2xvcjogd2hpdGU7XHJcbiAgYm9yZGVyLWJvdHRvbTogMXB4IHNvbGlkIHJnYmEoMCwgMCwgMCwgLjIpO1xyXG4gIC51c2VyLWJ1dHRvbiB7XHJcbiAgICBiYWNrZ3JvdW5kLWNvbG9yOiAjZjdmN2Y3O1xyXG4gICAgLmZhcyB7XHJcbiAgICAgIGZvbnQtc2l6ZTogMjJweDtcclxuICAgIH1cclxuICB9XHJcbiAgLmJyYW5kLWxvZ28ge1xyXG4gICAgaGVpZ2h0OiA4MHB4O1xyXG4gICAgd2lkdGg6IDgwcHg7XHJcbiAgfVxyXG5cclxuICAuc2VhcmNoLWNvbnRhaW5lciB7XHJcbiAgICBtYXJnaW4tbGVmdDogODVweDtcclxuICAgIGRpc3BsYXk6IGZsZXg7XHJcbiAgICBmbGV4LWRpcmVjdGlvbjogcm93O1xyXG4gICAgYWxpZ24taXRlbXM6IGNlbnRlcjtcclxuICAgIGJhY2tncm91bmQtY29sb3I6ICNmN2Y3Zjc7XHJcbiAgICBib3JkZXItcmFkaXVzOiA0cHg7XHJcblxyXG4gICAgLmZhcyB7XHJcbiAgICAgIG1hcmdpbjogMCAxMHB4O1xyXG4gICAgfVxyXG5cclxuICAgIGlucHV0IHtcclxuICAgICAgaGVpZ2h0OiA0MHB4O1xyXG4gICAgICB3aWR0aDogNDAwcHg7XHJcbiAgICAgIGJhY2tncm91bmQtY29sb3I6IHRyYW5zcGFyZW50O1xyXG4gICAgICBib3JkZXI6IDA7XHJcbiAgICAgIG91dGxpbmUtd2lkdGg6IDA7XHJcbiAgICB9XHJcbiAgfVxyXG59XHJcblxyXG4iLCIudG9vbGJhciB7XG4gIGJhY2tncm91bmQtY29sb3I6IHdoaXRlO1xuICBib3JkZXItYm90dG9tOiAxcHggc29saWQgcmdiYSgwLCAwLCAwLCAwLjIpO1xufVxuLnRvb2xiYXIgLnVzZXItYnV0dG9uIHtcbiAgYmFja2dyb3VuZC1jb2xvcjogI2Y3ZjdmNztcbn1cbi50b29sYmFyIC51c2VyLWJ1dHRvbiAuZmFzIHtcbiAgZm9udC1zaXplOiAyMnB4O1xufVxuLnRvb2xiYXIgLmJyYW5kLWxvZ28ge1xuICBoZWlnaHQ6IDgwcHg7XG4gIHdpZHRoOiA4MHB4O1xufVxuLnRvb2xiYXIgLnNlYXJjaC1jb250YWluZXIge1xuICBtYXJnaW4tbGVmdDogODVweDtcbiAgZGlzcGxheTogZmxleDtcbiAgZmxleC1kaXJlY3Rpb246IHJvdztcbiAgYWxpZ24taXRlbXM6IGNlbnRlcjtcbiAgYmFja2dyb3VuZC1jb2xvcjogI2Y3ZjdmNztcbiAgYm9yZGVyLXJhZGl1czogNHB4O1xufVxuLnRvb2xiYXIgLnNlYXJjaC1jb250YWluZXIgLmZhcyB7XG4gIG1hcmdpbjogMCAxMHB4O1xufVxuLnRvb2xiYXIgLnNlYXJjaC1jb250YWluZXIgaW5wdXQge1xuICBoZWlnaHQ6IDQwcHg7XG4gIHdpZHRoOiA0MDBweDtcbiAgYmFja2dyb3VuZC1jb2xvcjogdHJhbnNwYXJlbnQ7XG4gIGJvcmRlcjogMDtcbiAgb3V0bGluZS13aWR0aDogMDtcbn0iXX0= */"},ynWL:function(t,n){t.exports=".app-container {\n  -webkit-box-flex: 1;\n          flex-grow: 1;\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-orient: horizontal;\n  -webkit-box-direction: normal;\n          flex-direction: row;\n}\n.app-container .current-component-container {\n  display: -webkit-box;\n  display: flex;\n  -webkit-box-flex: 1;\n          flex-grow: 1;\n}\n/*# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInNyYy9hcHAvQzpcXFJlcG9zXFxXYWxsZXRLZWVwZXJcXHNyY1xcV2FsbGV0LldlYlNQQVxcQ2xpZW50XFx3YWxsZXQvc3JjXFxhcHBcXGFwcC5jb21wb25lbnQuc2NzcyIsInNyYy9hcHAvYXBwLmNvbXBvbmVudC5zY3NzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiJBQUNBO0VBQ0UsbUJBQUE7VUFBQSxZQUFBO0VBQ0Esb0JBQUE7RUFBQSxhQUFBO0VBQ0EsOEJBQUE7RUFBQSw2QkFBQTtVQUFBLG1CQUFBO0FDQUY7QURDRTtFQUNFLG9CQUFBO0VBQUEsYUFBQTtFQUNBLG1CQUFBO1VBQUEsWUFBQTtBQ0NKIiwiZmlsZSI6InNyYy9hcHAvYXBwLmNvbXBvbmVudC5zY3NzIiwic291cmNlc0NvbnRlbnQiOlsiXHJcbi5hcHAtY29udGFpbmVye1xyXG4gIGZsZXgtZ3JvdzogMTtcclxuICBkaXNwbGF5OiBmbGV4O1xyXG4gIGZsZXgtZGlyZWN0aW9uOiByb3c7XHJcbiAgLmN1cnJlbnQtY29tcG9uZW50LWNvbnRhaW5lcntcclxuICAgIGRpc3BsYXk6IGZsZXg7XHJcbiAgICBmbGV4LWdyb3c6IDE7XHJcbiAgfVxyXG59XHJcbiIsIi5hcHAtY29udGFpbmVyIHtcbiAgZmxleC1ncm93OiAxO1xuICBkaXNwbGF5OiBmbGV4O1xuICBmbGV4LWRpcmVjdGlvbjogcm93O1xufVxuLmFwcC1jb250YWluZXIgLmN1cnJlbnQtY29tcG9uZW50LWNvbnRhaW5lciB7XG4gIGRpc3BsYXk6IGZsZXg7XG4gIGZsZXgtZ3JvdzogMTtcbn0iXX0= */"},zUnb:function(t,n,c){"use strict";c.r(n);c("yLV6");var i=c("8Y7J"),o=c("wAiw"),e=c("mrSG"),a=c("cUpR"),s=c("iInd"),b=c("IheW");function l(t){return`http://localhost:5000/api/v1/ac/account/${t}`}var g=c("ZNab");let r=class{constructor(t){this.http=t}setToken(t){this._token=t}get(t,n=null){let c=(new b.c).set("Content-Type","application/json");return this._token&&(c=c.set("Authorization",`Bearer ${this._token}`)),this.http.get(t,{params:n,headers:c})}post(t,n){let c=(new b.c).set("Content-Type","application/json");return this._token&&(c=c.set("Authorization",`Bearer ${this._token}`)),this.http.post(t,n,{headers:c})}put(t,n){let c=(new b.c).set("Content-Type","application/json");return this._token&&(c=c.set("Authorization",`Bearer ${this._token}`)),this.http.put(t,n,{headers:c})}};r.ctorParameters=()=>[{type:b.a}],r=e.a([Object(i.C)({providedIn:"root"})],r);let u=class{constructor(t,n){this.cookies=t,this.http=n,this.loggedIn=new i.w;const c=this.cookies.get("st");c&&this.http.setToken(c)}isLoggedIn(){return this.cookies.check("st")}login(){this.loggedIn.emit();const t=this.cookies.get("st");this.http.setToken(t)}logout(){this.cookies.delete("st")}};u.ctorParameters=()=>[{type:g.a},{type:r}],u=e.a([Object(i.C)({providedIn:"root"})],u);let d=class{constructor(t,n,c,i){this.http=t,this.router=n,this.cookie=c,this.busy=!1,i.isLoggedIn()&&n.navigate(["/"])}ngOnInit(){}login(){this.busy=!0,this.message="",this.http.post("http://localhost:5000/api/v1/a/auth/authenticate",{username:this.username,password:this.password}).subscribe(t=>{t.isSuccessful?(this.cookie.set("st",t.token),location.reload()):this.message=t.message,this.busy=!1},t=>{401==t.status?this.message=t.error.message:(this.message="couldn't connect to the api.",console.error(t)),this.busy=!1})}};d.ctorParameters=()=>[{type:b.a},{type:s.a},{type:g.a},{type:u}],d=e.a([Object(i.n)({selector:"app-login",template:c("rkYV"),styles:[c("ZTFi")]})],d);let x=class{constructor(){}ngOnInit(){}};x=e.a([Object(i.n)({selector:"app-home",template:c("7R3X"),styles:[c("bdh1")]})],x);let p=class{constructor(t,n){this.authService=t,this.router=n}canActivate(){return!!this.authService.isLoggedIn()||(this.router.navigate(["login"]),!1)}};p.ctorParameters=()=>[{type:u},{type:s.a}],p=e.a([Object(i.C)({providedIn:"root"})],p);var I=c("s6ns"),m=c("dFDH");let B=class{constructor(t,n,c){this.dialogRef=t,this.http=n,this.snack=c}ngOnInit(){this.types=[],this.http.get("http://localhost:5000/api/v1/ac/account/getTypes").subscribe(t=>{this.types=t,this.types&&this.types.length>0&&(this.selectedType=this.types[0].id)})}save(){this.busy=!0;const t={title:this.title,accountTypeId:this.selectedType};this.http.post("http://localhost:5000/api/v1/ac/account/",t).subscribe(t=>{this.busy=!1,this.snack.open("Account created successfully","close",{duration:300}),this.dialogRef.close(t)},t=>{this.busy=!1,this.snack.open("Something went wrong!","close",{duration:300})})}};B.ctorParameters=()=>[{type:I.d},{type:r},{type:m.a}],B=e.a([Object(i.n)({selector:"app-create-account",template:c("Gf7b"),styles:[c("eekT")]})],B);var X=c("cp0P");let G=class{constructor(t,n,c,i){this.dialogRef=t,this.http=n,this.snack=c,this.id=i.id,this.title=i.title}ngOnInit(){}save(){this.busy=!0;const t={id:this.id,title:this.title};this.http.put("http://localhost:5000/api/v1/ac/account/",t).subscribe(t=>{this.busy=!1,this.snack.open("Account edited successfully","close",{duration:300}),this.dialogRef.close(t)},t=>{this.busy=!1,this.snack.open("Something went wrong!","close",{duration:300})})}};G.ctorParameters=()=>[{type:I.d},{type:r},{type:m.a},{type:void 0,decorators:[{type:i.B,args:[I.a]}]}],G=e.a([Object(i.n)({selector:"app-edit-account",template:c("5BDf"),styles:[c("haLy")]}),e.b(3,Object(i.B)(I.a))],G);let F=class{constructor(t,n){this.dialog=t,this.http=n,this.accounts=[],this.busy=!1}ngOnInit(){this.busy=!0;const t=this.http.get("http://localhost:5000/api/v1/ac/account/");t.subscribe(t=>{this.accounts=t}),Object(X.a)(t).subscribe(()=>this.busy=!1)}createAccount(){this.dialog.open(B).afterClosed().subscribe(t=>{t&&this.http.get(l(t.id)).subscribe(t=>this.accounts.push(t))})}edit(t){this.dialog.open(G,{data:t}).afterClosed().subscribe(()=>{this.http.get(l(t.id)).subscribe(n=>{const c=this.accounts.indexOf(t);this.accounts[c]=n})})}};F.ctorParameters=()=>[{type:I.b},{type:r}];const Q=[{path:"login",component:d},{path:"home",component:x,canActivate:[p]},{path:"accounts",component:F=e.a([Object(i.n)({selector:"app-accounts",template:c("k6/D"),styles:[c("U0zd")]})],F),canActivate:[p]},{path:"",redirectTo:"/home",pathMatch:"full"}];let h=class{};h=e.a([Object(i.K)({imports:[s.b.forRoot(Q)],exports:[s.b]})],h);var y=c("Gi4r");let Z=class{constructor(t,n,c){this.matIconRegistry=t,this.domSanitizer=n,this.title="wallet",this.IconsConfiglet(t,n),this.loggedin=c.isLoggedIn(),c.loggedIn.subscribe(()=>{this.loggedin=c.isLoggedIn()})}IconsConfiglet(t,n){t.addSvgIcon("logo",n.bypassSecurityTrustResourceUrl("../assets/Logo-colored.svg")),t.addSvgIcon("logo-mini",n.bypassSecurityTrustResourceUrl("../assets/Logo-colored-mini.svg"))}};Z.ctorParameters=()=>[{type:y.b},{type:a.b},{type:u}],Z=e.a([Object(i.n)({selector:"app-root",template:c("lILz"),styles:[c("ynWL")]})],Z);var C=c("SVse"),W=c("HsOI"),V=c("ZwOa"),Y=c("igqZ"),J=c("Fwaw"),U=c("8P0U"),v=c("s7LF");let w=class{};w=e.a([Object(i.K)({declarations:[d],imports:[C.b,W.c,V.a,v.b,Y.a,J.a,b.b,U.a]})],w);var L=c("omvX");let A=class{};A=e.a([Object(i.K)({declarations:[x],imports:[C.b]})],A);let j=class{constructor(t){this.authService=t}ngOnInit(){}logout(){this.authService.logout(),location.reload()}};j.ctorParameters=()=>[{type:u}],j=e.a([Object(i.n)({selector:"app-toolbar",template:c("okTi"),styles:[c("uiS6")]})],j);var H=c("BzsH"),N=c("gavF");let O=class{constructor(){}ngOnInit(){}};O=e.a([Object(i.n)({selector:"app-sidebar",template:c("M+Fk"),styles:[c("UaI1")]})],O);var R=c("JjoW"),k=c("Q+lL"),f=c("c9fC");let z=class{};z=e.a([Object(i.K)({declarations:[F,B,G],imports:[C.b,v.b,V.a,R.a,k.a,J.a,f.a,I.c,m.b,U.a],entryComponents:[B,G]})],z);let D=class{};D=e.a([Object(i.K)({declarations:[Z,j,O],imports:[a.a,h,L.b,y.a,H.a,J.a,v.b,V.a,N.a,w,A,z],providers:[g.a,r,u],bootstrap:[Z]})],D);Object(o.a)().bootstrapModule(D).catch(t=>console.error(t))},zn8P:function(t,n){function c(t){return Promise.resolve().then(function(){var n=new Error("Cannot find module '"+t+"'");throw n.code="MODULE_NOT_FOUND",n})}c.keys=function(){return[]},c.resolve=c,t.exports=c,c.id="zn8P"}},[[0,0,4]]]);
//# sourceMappingURL=main-es2015.js.map