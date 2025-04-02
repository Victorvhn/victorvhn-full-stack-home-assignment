"use server";

import { fetchApi } from "@/lib/fetch-api";
import { PersonDto } from "@/types/persons/person-dto";

interface RequestParams {
  treeId: string;
}

async function getFamilyMembersByTreeId({ treeId }: RequestParams) {
  const url = `${process.env.API_URL!}/trees/${treeId}/family-members`;

  return fetchApi<PersonDto[]>(url);
}

export { getFamilyMembersByTreeId };
