import { getFamilyMembersByTreeId } from "@/actions/trees/get-family-members-by-id";
import { PersonSelect } from "@/components/person-select";
import { TreeSelector } from "@/components/tree-selector";
import { tryFetch } from "@/lib/try-fetch";

const defaultFamilyTreeId = "0195f373-c5e5-70b6-95be-7e7e003b4b7a";

interface PageQueryParams {
  treeId?: string;
}

export default async function Page({ searchParams }: { searchParams: Promise<PageQueryParams> }) {
  const { treeId } = await searchParams;

  const { data, error, isFailure } = await tryFetch(
    getFamilyMembersByTreeId({ treeId: treeId || defaultFamilyTreeId })
  );

  if (isFailure || !data) {
    throw error;
  }

  return (
    <main className="min-h-screen bg-gradient-to-b from-emerald-50 to-teal-100">
      <div className="container mx-auto px-4 py-12">
        <div className="mx-auto max-w-3xl rounded-xl bg-white p-8 shadow-xl">
          <div className="mb-10 text-center">
            <h1 className="mb-3 text-4xl font-bold text-emerald-600">Family Tree App</h1>
          </div>

          <div className="space-y-8">
            <section>
              <h2 className="mb-4 text-xl font-semibold text-slate-800">Select a Family Tree</h2>
              <TreeSelector />
            </section>

            <section>
              <PersonSelect data={data} />
            </section>
          </div>
        </div>
      </div>
    </main>
  );
}
