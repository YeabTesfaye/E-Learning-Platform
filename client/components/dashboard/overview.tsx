"use client";

import {
  Line,
  LineChart,
  ResponsiveContainer,
  Tooltip,
  XAxis,
  YAxis,
} from "recharts";

const data = [
  {
    name: "Jan",
    hours: 12,
  },
  {
    name: "Feb",
    hours: 18,
  },
  {
    name: "Mar",
    hours: 24,
  },
  {
    name: "Apr",
    hours: 32,
  },
  {
    name: "May",
    hours: 28,
  },
  {
    name: "Jun",
    hours: 35,
  },
];

export function Overview() {
  return (
    <ResponsiveContainer width="100%" height={350}>
      <LineChart data={data}>
        <XAxis
          dataKey="name"
          stroke="#888888"
          fontSize={12}
          tickLine={false}
          axisLine={false}
        />
        <YAxis
          stroke="#888888"
          fontSize={12}
          tickLine={false}
          axisLine={false}
          tickFormatter={(value) => `${value}h`}
        />
        <Tooltip />
        <Line
          type="monotone"
          dataKey="hours"
          stroke="#8884d8"
          strokeWidth={2}
          activeDot={{ r: 8 }}
        />
      </LineChart>
    </ResponsiveContainer>
  );
}
