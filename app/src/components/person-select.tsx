"use client";

import { useEffect, useState } from "react";
import { formatDate } from "date-fns";

import { PersonDto } from "@/types/persons/person-dto";
import { DropdownSelect } from "./ui/dropdown-select";

interface PersonSelectProps {
  data: PersonDto[];
}

export function PersonSelect({ data }: PersonSelectProps) {
  const [selectedPerson, setSelectedPerson] = useState<PersonDto | null>(null);

  useEffect(() => {
    if (selectedPerson) {
      const stillExists = data.some((person) => person.personId === selectedPerson.personId);
      if (!stillExists) {
        setSelectedPerson(null);
      }
    }
  }, [data, selectedPerson]);

  const options = data.map((person) => ({
    label: person.displayName,
    value: person.personId,
  }));

  const handleSelectOption = (value: string) => {
    const person = data.find((person) => person.personId === value);
    if (!person) {
      return;
    }

    setSelectedPerson(person);
  };

  return (
    <>
      <DropdownSelect
        options={options}
        onChange={handleSelectOption}
        value={selectedPerson?.personId}
        label="Select a person"
      />

      {selectedPerson && (
        <section className="mt-8 rounded-lg bg-emerald-50 p-6">
          <h2 className="mb-4 text-xl font-semibold text-emerald-700">Person Details</h2>

          <div className="grid grid-cols-1 gap-4 md:grid-cols-2">
            <div className="rounded-md bg-white p-4 shadow-sm">
              <h3 className="mb-2 text-lg font-medium text-emerald-600">Basic Information</h3>
              <dl className="space-y-2">
                <div>
                  <dt className="text-sm font-medium text-gray-500">Display Name</dt>
                  <dd className="font-medium text-gray-900">{selectedPerson.displayName}</dd>
                </div>
                <div>
                  <dt className="text-sm font-medium text-gray-500">Given Name</dt>
                  <dd className="text-gray-900">{selectedPerson.givenName || "Unknown"}</dd>
                </div>
                <div>
                  <dt className="text-sm font-medium text-gray-500">Surname</dt>
                  <dd className="text-gray-900">{selectedPerson.surname || "Unknown"}</dd>
                </div>
                <div>
                  <dt className="text-sm font-medium text-gray-500">Gender</dt>
                  <dd className="text-gray-900">{selectedPerson.gender || "Unknown"}</dd>
                </div>
                <div>
                  <dt className="text-sm font-medium text-gray-500">Person ID</dt>
                  <dd className="font-mono text-sm text-gray-700">{selectedPerson.personId}</dd>
                </div>
                <div>
                  <dt className="text-sm font-medium text-gray-500">Family Tree ID</dt>
                  <dd className="font-mono text-sm text-gray-700">{selectedPerson.familyTreeId || "None"}</dd>
                </div>
              </dl>
            </div>

            <div className="rounded-md bg-white p-4 shadow-sm">
              <h3 className="mb-2 text-lg font-medium text-emerald-600">Life Events</h3>

              <div className="mb-4">
                <h4 className="text-sm font-medium text-gray-500">Birth</h4>
                <dl className="mt-2 space-y-1">
                  <div>
                    <dt className="inline text-sm font-medium text-gray-500">Date: </dt>
                    <dd className="ml-1 inline text-gray-900">
                      {selectedPerson.birthDate ? formatDate(selectedPerson.birthDate, "MMMM d, yyyy") : "Unknown"}
                    </dd>
                  </div>
                  <div>
                    <dt className="inline text-sm font-medium text-gray-500">Location: </dt>
                    <dd className="ml-1 inline text-gray-900">{selectedPerson.birthLocation || "Unknown"}</dd>
                  </div>
                </dl>
              </div>

              <div>
                <h4 className="text-sm font-medium text-gray-500">Death</h4>
                <dl className="mt-2 space-y-1">
                  <div>
                    <dt className="inline text-sm font-medium text-gray-500">Date: </dt>
                    <dd className="ml-1 inline text-gray-900">
                      {selectedPerson.deathDate ? formatDate(selectedPerson.deathDate, "MMMM d, yyyy") : "Unknown"}
                    </dd>
                  </div>
                  <div>
                    <dt className="inline text-sm font-medium text-gray-500">Location: </dt>
                    <dd className="ml-1 inline text-gray-900">{selectedPerson.deathLocation || "Unknown"}</dd>
                  </div>
                </dl>
              </div>
            </div>
          </div>
        </section>
      )}
    </>
  );
}
