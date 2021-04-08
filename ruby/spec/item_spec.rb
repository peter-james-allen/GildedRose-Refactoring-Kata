require 'item'

describe Item do
  let(:subject) { Item.new("Plumbus", 3, 10) }

  it 'should store name, sell_in and quality' do
    expect(subject.name).to eq "Plumbus"
    expect(subject.sell_in).to eq 3
    expect(subject.quality).to eq 10
  end

  it 'should let you alter name, sell_in and quality' do
    subject.name = "Mace"
    subject.sell_in = 1
    subject.quality = 2

    expect(subject.name).to eq "Mace"
    expect(subject.sell_in).to eq 1
    expect(subject.quality).to eq 2
  end

  it 'should format item to string' do
    expect(subject.to_s).to eq "Plumbus, 3, 10"
  end
end
