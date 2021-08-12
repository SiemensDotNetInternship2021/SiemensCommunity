import { AbstractControl, ValidationErrors } from "@angular/forms";

export class ChangeValueValidator {
    static isValueChanged(control: AbstractControl) : ValidationErrors | null {
        if((control.value as string)) {
            return {isValueChanged : true}
        }

        return null;
    }
}