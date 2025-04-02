"use client";

import { useQueryState } from "nuqs";

import { Button } from "./ui/button";

// It should be queried from the server but for now I'll use a hardcoded value
const trees = [
  {
    key: "0195f373-c5e5-70b6-95be-7e7e003b4b7a",
    name: "Family Tree 1",
  },
  {
    key: "0195f373-c5e5-735c-9a59-b323f0f7092a",
    name: "Family Tree 2",
  },
  {
    key: "0195f373-c5e5-7593-9b26-9af5b901817a",
    name: "Family Tree 3",
  },
  {
    key: "0195f373-c5e5-76a2-a287-a46836ddaa72",
    name: "Family Tree 4",
  },
  {
    key: "0195f373-c5e5-7933-8d29-eccefc32f5fa",
    name: "Family Tree 5",
  },
  {
    key: "0195f373-c756-72e6-81bf-d85ad7a2a321",
    name: "Family Tree 6",
  },
];

export function TreeSelector() {
  const [treeId, setTreeId] = useQueryState("treeId", {
    shallow: false,
    defaultValue: "0195f373-c5e5-70b6-95be-7e7e003b4b7a",
  });

  return (
    <div className="mb-6 flex flex-wrap gap-3">
      {trees.map((tree) => (
        <Button
          key={tree.key}
          onClick={() => setTreeId(tree.key)}
          variant={treeId === tree.key ? "default" : "outline"}
        >
          {tree.name}
        </Button>
      ))}
    </div>
  );
}
