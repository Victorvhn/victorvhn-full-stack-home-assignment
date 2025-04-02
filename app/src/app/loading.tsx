export default function Loading() {
  return (
    <main className="min-h-screen bg-gradient-to-b from-emerald-50 to-teal-100">
      <div className="container mx-auto px-4 py-12">
        <div className="mx-auto max-w-3xl rounded-xl bg-white p-8 shadow-xl">
          <div className="mb-10 text-center">
            <div className="mx-auto mb-3 h-10 w-64 animate-pulse rounded-lg bg-emerald-200" />
          </div>

          <div className="space-y-8">
            <section>
              <div className="mb-4 h-7 w-48 animate-pulse bg-slate-200" />

              <div className="flex flex-wrap gap-3">
                {[1, 2, 3, 4, 5, 6].map((i) => (
                  <div key={i} className="h-10 w-32 animate-pulse bg-slate-200" />
                ))}
              </div>
            </section>

            <section>
              <div className="mb-4 h-6 w-32 animate-pulse rounded-md bg-slate-200" />
              <div className="flex h-12 w-full animate-pulse items-center justify-end bg-slate-200 pr-4" />
            </section>
          </div>
        </div>
      </div>
    </main>
  );
}
