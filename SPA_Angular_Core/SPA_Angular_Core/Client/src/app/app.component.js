var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Car } from './car';
let AppComponent = /** @class */ (() => {
    let AppComponent = class AppComponent {
        constructor(dataService) {
            this.dataService = dataService;
            this.car = new Car();
            this.tableMode = true;
        }
        ngOnInit() {
            this.loadCars();
        }
        loadCars() {
            this.dataService.getCars()
                .subscribe((data) => this.cars = data);
        }
        save() {
            if (this.car.id == null) {
                this.dataService.createCar(this.car)
                    .subscribe((data) => this.cars.push(data));
            }
            else {
                this.dataService.updateCar(this.car)
                    .subscribe(data => this.loadCars);
            }
            this.cancel();
        }
        editCar(car) {
            this.car = car;
        }
        cancel() {
            this.car = new Car();
            this.tableMode = true;
        }
        delete(car) {
            this.dataService.deleteCar(car.id)
                .subscribe(data => this.loadCars());
        }
        add() {
            this.cancel();
            this.tableMode = false;
        }
    };
    AppComponent = __decorate([
        Component({
            selector: 'app',
            templateUrl: './app.component.html',
            providers: [DataService]
        })
    ], AppComponent);
    return AppComponent;
})();
export { AppComponent };
//# sourceMappingURL=app.component.js.map