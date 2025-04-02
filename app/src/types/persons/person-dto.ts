export enum PersonGender {
  Male = 1,
  Female = 2,
}

export type PersonDto = {
  personId: string;
  givenName: string;
  surname: string;
  gender: PersonGender;
  birthDate: string | null;
  birthLocation: string | null;
  deathDate: string | null;
  deathLocation: string | null;
  familyTreeId: string | null;
  displayName: string;
};
