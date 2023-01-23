import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {Observable, tap} from "rxjs";
import {UserModel} from "../../models/UserModel";
import {DataAccessService} from "../../services/data-access.service";
import {HttpService} from "../../services/http.service";

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  allUsers: UserModel[] = [];
  allUsersObservable!: Observable<UserModel[]>;
  userModel: Partial<UserModel> = {};

  constructor(
    private dataAccess: DataAccessService,
    private httpService: HttpService,
    public changeDetector: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.allUsersObservable = this.dataAccess.getAllUsers();
    this.allUsersObservable.subscribe(list => this.allUsers = list);
  }

  async submit() {
    let user = this.httpService.postUser(this.userModel as UserModel).subscribe(
      result => {console.log(result); this.allUsers.push(result);},
      error => console.error(error)
    );

    // TODO Get rid of timeout

    //this.allUsers = this.dataAccess.getAllUsers();
  }
}
